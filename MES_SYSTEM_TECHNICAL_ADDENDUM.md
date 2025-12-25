# MES SYSTEM - Technical Addendum
## Manufacturing Execution System Deep Dive

**Document Purpose:** This addendum provides detailed technical specifications for the MES (Manufacturing Execution System) in Engine Assembly Tycoon, incorporating real-world protocols (OPC-UA, ISA-95), communication standards, and authentic manufacturing workflows.

**Integration Note:** This document expands Section 3 of the main GDD with technical depth for implementation.

---

## 1. MES Architecture Overview (ISA-95 Hierarchy)

The game's MES system follows the **ISA-95 standard** (ANSI/ISA-95), which defines 5 levels of manufacturing control:

```
┌────────────────────────────────────────────────────────────┐
│ LEVEL 4: ERP (Enterprise Resource Planning)               │
│ - Material procurement, financial planning                 │
│ - Order management, supply chain                           │
│ - GAME SYSTEM: Economy Manager, Contract Manager           │
└─────────────────────┬──────────────────────────────────────┘
                      │ (Business Planning ↔ Production)
┌─────────────────────▼──────────────────────────────────────┐
│ LEVEL 3: MES (Manufacturing Execution System)             │
│ - Work order management, scheduling                        │
│ - Production tracking, genealogy                           │
│ - Quality management, performance analysis                 │
│ - GAME SYSTEM: MES Manager (Player-Configurable)           │
└─────────────────────┬──────────────────────────────────────┘
                      │ (Production Commands ↔ Machine Data)
┌─────────────────────▼──────────────────────────────────────┐
│ LEVEL 2: SCADA / HMI (Supervisory Control)                │
│ - Real-time monitoring, operator interface                 │
│ - Data acquisition, alarm management                       │
│ - GAME SYSTEM: Machine Detail Panels, Status Displays      │
└─────────────────────┬──────────────────────────────────────┘
                      │ (Setpoints ↔ Sensor Data)
┌─────────────────────▼──────────────────────────────────────┐
│ LEVEL 1: PLC (Programmable Logic Controller)              │
│ - Machine control logic, NC program execution             │
│ - Sensor processing, actuator commands                    │
│ - GAME SYSTEM: Machine State Logic (Abstracted)            │
└─────────────────────┬──────────────────────────────────────┘
                      │ (Control Signals ↔ Physical I/O)
┌─────────────────────▼──────────────────────────────────────┐
│ LEVEL 0: Physical Process                                 │
│ - Motors, sensors, tools, actuators                       │
│ - GAME SYSTEM: Visual animations, particle effects         │
└────────────────────────────────────────────────────────────┘
```

**Gameplay Translation:**
- **Player primarily interacts with Level 3 (MES)** - creating rules, monitoring production
- **Level 4 (ERP)** provides high-level data (materials available, contract requirements)
- **Levels 0-2** are abstracted (machines "just work" based on MES commands)
- **Advanced players** can inspect Level 2 (SCADA) for debugging and optimization

---

## 2. Communication Protocols

### 2.1 OPC-UA (Open Platform Communications - Unified Architecture)

**Real-World Standard:** OPC-UA is the industry-standard protocol for industrial communication, replacing proprietary protocols.

**Why OPC-UA Matters in Our Game:**
- **Multi-Vendor Interoperability:** Different machine brands (CNC from Brand A, Nutrunners from Brand B) communicate seamlessly
- **Security:** Built-in encryption, authentication (important for late-game networked factory scenarios)
- **Platform Independence:** Works on Windows, Linux, embedded systems (future-proofs game for cloud features)

**Game Implementation (Abstracted for Gameplay):**

**Visual Representation:**
```
[MES Server] ←→ [OPC-UA Network] ←→ [Machine Clients]
     ↓                                      ↓
 [Player MES UI]                    [CNC, Lathe, Nutrunner]
```

**How It Works In-Game:**

1. **MES Sends Work Order (Player Action):**
   ```
   Player clicks "Start Production: Engine Block v2"
   
   MES generates OPC-UA command:
   {
     "node": "CNC_Machine_01",
     "command": "ExecuteWorkOrder",
     "parameters": {
       "partNumber": "ENG-BLK-v2-12345",
       "ncProgram": "PROG_ENG_BLK_V2.nc",
       "material": "Aluminum_6061",
       "quantity": 1,
       "priority": "Normal",
       "torqueProfile": "Standard_85Nm"
     }
   }
   ```

2. **Machine Receives Command (PLC Level):**
   ```
   CNC PLC receives OPC-UA message
   Loads NC program from memory
   Validates tool availability (Tool #5: 12mm end mill)
   Sets spindle speed: 2500 RPM
   Sets feed rate: 250 mm/min
   Executes program
   ```

3. **Machine Reports Status (Real-Time Telemetry):**
   ```
   Every 1 second, machine publishes to OPC-UA:
   {
     "machineID": "CNC_Machine_01",
     "status": "Running",
     "currentOperation": "Roughing_Pass_1",
     "progress": 0.35,  // 35% complete
     "spindleRPM": 2487,  // Actual speed (slightly below setpoint)
     "toolWear": 0.23,     // 23% worn
     "powerConsumption": 7.2,  // kW
     "partCount": 0  // Not complete yet
   }
   ```

4. **MES Processes Data:**
   ```
   MES aggregates data:
   - Updates machine status overlay (green = running)
   - Displays progress bar (35%)
   - Predicts completion time: 8.5 minutes remaining
   - Logs power consumption for cost tracking
   ```

5. **Cycle Complete - Machine Notifies MES:**
   ```
   {
     "machineID": "CNC_Machine_01",
     "status": "Complete",
     "partNumber": "ENG-BLK-v2-12345",
     "serialNumber": "ENG-BLK-v2-12345-S00001",  // Auto-generated
     "actualCycleTime": 720,  // seconds (12 min)
     "qualityData": {
       "dimensionX": 200.02,  // mm (target: 200.00 ± 0.05)
       "dimensionY": 150.01,  // mm (target: 150.00 ± 0.05)
       "surfaceFinish": "Ra_1.2"  // Roughness average
     },
     "toolWearDelta": 0.08,  // Tool wore 8% during this cycle
     "timestamp": "2025-12-20T14:35:22Z"
   }
   ```

6. **MES Actions:**
   - Update part genealogy database (serial number logged)
   - Send part to next station (Assembly) via conveyor/AGV command
   - Update ERP inventory: -1 aluminum billet, +1 engine block (semi-finished)
   - Check quality data: dimensions within spec → PASS (if not, trigger QC alert)
   - Log tool wear → if >70%, schedule maintenance

**Player Visibility:**
- **Basic View:** Machine turns green, progress bar, completion notification
- **Advanced View (MES Panel Open):** Full telemetry stream, quality metrics, predictive maintenance alerts

---

### 2.2 MQTT (Message Queuing Telemetry Transport) - IIoT Protocol

**Use Case in Game:** Lightweight telemetry for sensors, AGVs, mobile workers (Phase 4+)

**Example - AGV Fleet Management:**
```
AGV_01 publishes to topic: "factory/agv/01/status"
{
  "agvID": "AGV_01",
  "location": {"x": 25, "y": 18},
  "battery": 78,  // %
  "taskStatus": "Transporting",
  "payload": "Part_ENG-BLK-v2-12345",
  "destination": "Assembly_Station_03"
}

MES subscribes to "factory/agv/+/status" (all AGVs)
Updates AGV position on factory map
If battery <20%, send to charging station
```

**Gameplay Impact:**
- Player sees AGVs moving in real-time on factory floor
- Can click AGV for detailed status (MQTT data displayed)
- MES dashboard shows "AGV Fleet Status" panel (all AGV metrics aggregated)

---

## 3. MES Core Functions (MESA-11 Model)

The **Manufacturing Enterprise Solutions Association (MESA)** defined 11 core MES functions. Here's how each maps to gameplay:

### 3.1 Resource Allocation and Status

**Real-World:** Track machines, tools, materials, labor availability  
**In-Game:**  
- **Machine Status Dashboard:** IDLE / SETUP / RUNNING / MAINTENANCE / ERROR
- **Worker Availability:** Assigned / Unassigned / On Break / Training
- **Material Inventory:** Real-time stock levels (updated via ERP integration)
- **Tool Crib:** Track tool availability, wear, location

**Functional Example:**
```
Player receives work order: "Produce 50 engine blocks"

MES checks resources:
✓ CNC_01: Available
✓ Worker_Jane (Skill 75): Available
✓ Material (Aluminum): 52 billets in stock (sufficient)
✗ Tool (12mm end mill): All 3 tools have >80% wear

MES Action: Suggest tool replacement before starting production
Player Decision: 
  A. Replace tools now ($600, 20 min delay)
  B. Proceed with worn tools (risk: higher scrap rate)
```

---

### 3.2 Operations / Detailed Scheduling

**Real-World:** Sequence work orders, optimize machine utilization  
**In-Game:**  
- **Production Scheduler:** Drag-and-drop work orders onto timeline
- **Auto-Scheduling (MES-Assisted):** Optimize for earliest completion, lowest cost, or balanced load
- **Constraint Awareness:** MES flags conflicts (e.g., 2 jobs need same machine simultaneously)

**Scheduling Strategies:**

**A. FIFO (First-In-First-Out):**
```
Order 1: 100× v1 engines → Start immediately
Order 2: 50× v2 engines → Wait until Order 1 complete
Order 3: 75× v3 engines → Wait until Order 2 complete

Total Time: 18 hours
Advantage: Simple, fair
Disadvantage: May miss urgent deadlines
```

**B. Shortest Job First (SJF):**
```
Order 2: 50× v2 (3 hours) → Start first
Order 3: 75× v3 (5 hours) → Next
Order 1: 100× v1 (10 hours) → Last

Total Time: 18 hours (same)
Advantage: Reduces average wait time, completes more orders faster
Disadvantage: Large orders delayed
```

**C. Critical Ratio (Deadline-Driven):**
```
Calculate: CriticalRatio = (Deadline - CurrentTime) / RemainingProcessTime

Order 1: Deadline in 8 hours, 10 hours work = CR: 0.8 (URGENT!)
Order 2: Deadline in 12 hours, 3 hours work = CR: 4.0 (relaxed)
Order 3: Deadline in 10 hours, 5 hours work = CR: 2.0 (moderate)

Priority: Order 1 → Order 3 → Order 2

Total Time: 18 hours, but Order 1 delivered on time (late penalties avoided)
```

**MES Automation (Player-Configurable):**
```
IF Contract.deadline < 24 hours THEN
  Scheduler.priority = "CriticalRatio"
ELSE
  Scheduler.priority = "SJF"  // Optimize throughput
END
```

---

### 3.3 Dispatching Production Units

**Real-World:** Send work instructions to machines/operators  
**In-Game:**  
- **Work Instruction Display:** HMI screen at each station shows:
  - Part number, quantity, specifications
  - Step-by-step assembly sequence (with images)
  - Required tools, torque specs
  - QC checkpoints
- **Digital Work Orders:** Paperless - instructions sent via MES to tablets/HMIs

**Functional Example (Atlas Nutrunner Station):**
```
Worker arrives at Assembly Station 3
HMI screen displays (MES-pushed):

┌────────────────────────────────────────┐
│ WORK ORDER: WO-2025-1234               │
│ Product: Engine Block Assembly v2      │
│ Serial: ENG-v2-S00523                  │
├────────────────────────────────────────┤
│ STEP 3 of 8: Cylinder Head Bolting    │
│                                        │
│ Tools Required:                        │
│  • Atlas Nutrunner #2                 │
│  • Torque: 85 Nm ± 1 Nm               │
│  • Angle: 60° (after torque reached)  │
│                                        │
│ Sequence (CRITICAL):                   │
│  1. Bolt A1 (front-left)              │
│  2. Bolt A4 (rear-right)              │
│  3. Bolt A2 (front-right)             │
│  4. Bolt A3 (rear-left)               │
│  [Diagram showing bolt positions]      │
│                                        │
│ QC: Verify torque logged for each bolt│
│                                        │
│ [Button: Start Step]                  │
└────────────────────────────────────────┘
```

**Worker clicks "Start Step":**
- MES activates Atlas Nutrunner
- Nutrunner auto-configures to 85 Nm, 60° angle
- As worker tightens each bolt, nutrunner reports actual values to MES
- MES displays checklist: ✓ A1: 85.2 Nm, 59° (PASS)
- After all 4 bolts, MES advances to Step 4

**Benefit:** Zero worker error on torque specs, full traceability, enforced sequence

---

### 3.4 Document Control

**Real-World:** Manage work instructions, drawings, SOPs, batch records  
**In-Game:**  
- **Document Library:** Centralized repository of:
  - NC programs (G-code for CNC/Lathe)
  - Assembly instructions (PDFs, videos)
  - Quality specs (tolerance drawings)
  - Safety procedures
- **Version Control:** Only latest-approved documents accessible (prevents using obsolete specs)
- **ECO Integration:** When part revision occurs, MES auto-updates affected documents

**Functional Example (ECO Event):**
```
ECO-2025-042: "Crankshaft v1 → v2 (Material Change)"

MES Actions:
1. Archive old documents:
   - CRNK-v1-NCProgram.nc → marked "OBSOLETE"
   - CRNK-v1-AssemblyInst.pdf → marked "OBSOLETE"
   
2. Publish new documents:
   - CRNK-v2-NCProgram.nc → status "ACTIVE"
   - CRNK-v2-AssemblyInst.pdf → status "ACTIVE"
   - Updated torque spec sheet

3. Notify affected stations:
   - CNC_02 (machines crankshafts): New program available, load before next run
   - Assembly_05: New torque specs, review before shift start

4. Training requirement:
   - Flag workers assigned to crankshaft operations: "Training Required: CRNK-v2 Specs"
   - Player must schedule 2-hour training before production resumes
```

**Player Experience:**
- ECO event pops up with summary
- Player clicks "Accept ECO" → MES handles document updates automatically
- If player delays/ignores → production continues with old specs → quality failures ensue

---

### 3.5 Data Collection and Acquisition

**Real-World:** Gather machine data, operator inputs, sensor readings  
**In-Game:**  
- **Automatic Data Collection (OPC-UA):**
  - Machine cycle times, part counts, alarm codes
  - Quality measurements (dimensions from CMM)
  - Environmental sensors (temperature, humidity)
- **Manual Data Entry:**
  - Visual inspection results (worker input)
  - Material lot numbers (barcode scan)
  - Setup notes (worker comments)

**Data Types:**

| Data Category | Source | Frequency | Use |
|--------------|--------|-----------|-----|
| **Production Counts** | Machine PLC | Per cycle (every 10 min) | Throughput tracking, contract progress |
| **Quality Metrics** | QC Station | Per part or sample | Scrap rate, trend analysis |
| **Downtime Events** | Machine PLC | Real-time (when occurs) | OEE calculation, maintenance scheduling |
| **Material Usage** | ERP Integration | Per work order | Inventory depletion, cost tracking |
| **Worker Activity** | HMI login/logout | Per shift | Labor cost, efficiency analysis |
| **Energy Consumption** | Power meters | Per minute | Utility costs, sustainability metrics |

**Functional Example (Trend Detection):**
```
MES collects CNC dimensional data for 100 consecutive parts:

Part 1-20: Dimension X = 200.01 mm (target: 200.00 ± 0.05) → PASS
Part 21-40: Dimension X = 200.02 mm → PASS (trending upward)
Part 41-60: Dimension X = 200.03 mm → PASS (still in spec, but trend continues)
Part 61-80: Dimension X = 200.04 mm → WARNING (approaching upper limit)
Part 81: Dimension X = 200.06 mm → FAIL (out of spec)

MES SPC (Statistical Process Control) Analysis:
- Detects upward trend at Part 40
- Alerts player: "CNC_02 dimension X trending toward upper limit"
- Suggests: "Reduce spindle speed 5% to reduce thermal expansion"

Player Action:
  A. Ignore warning → Part 81 scrapped, may need rework for Parts 61-80
  B. Accept MES suggestion → Spindle reduced, Parts 41-100 all pass with X = 200.01-200.02 mm

Educational Value: Teaches predictive quality control, value of early intervention
```

---

### 3.6 Labor Management

**Real-World:** Track worker attendance, skills, certifications, productivity  
**In-Game:**  
- **Worker Database:** 
  - Skills, certifications, training history
  - Shift assignments, overtime tracking
  - Performance metrics (cycle time, error rate)
- **Time & Attendance:**
  - Clock in/out via HMI
  - Break tracking (ensures compliance with labor laws)
- **Skill Matrix:**
  - Visual heat map: which workers qualified for which stations
  - Cross-training tracker

**Skill Matrix Example:**
```
           CNC  Lathe  Assembly  QC  Nutrunner  Maintenance
Worker A    ✓✓    ✓      ✗       ✗      ✗          ✗
Worker B    ✓     ✓✓     ✓       ✗      ✗          ✗
Worker C    ✗     ✗      ✓✓      ✓      ✓✓         ✗
Worker D    ✗     ✗      ✓       ✓✓     ✓          ✓

✓✓ = Expert (100% efficiency)
✓  = Competent (85% efficiency)
✗  = Not trained

MES Optimization:
- Automatically suggests worker assignments based on skill match
- Identifies skill gaps: "No expert on Maintenance - consider training Worker B"
```

---

### 3.7 Quality Management

**Real-World:** Track defects, root cause analysis, corrective actions  
**In-Game:**  
- **Defect Tracking:**
  - Log every scrapped part: reason code, machine, worker, time
  - Pareto chart: most common defect types
- **SPC Charts:**
  - X-bar / R charts for critical dimensions
  - Trend detection (as shown in Data Collection example)
- **Root Cause Analysis:**
  - MES correlates defects with variables (worker skill, tool wear, material lot)
  - Suggests likely causes

**Pareto Analysis Example:**
```
Scrap Reasons (Last 100 Parts):
1. Dimensional Out-of-Spec: 38 parts (38%)
2. Surface Finish Poor: 22 parts (22%)
3. Tool Mark / Burr: 15 parts (15%)
4. Wrong Torque: 12 parts (12%)
5. Material Defect: 8 parts (8%)
6. Other: 5 parts (5%)

MES Root Cause Correlation:
Dimensional Out-of-Spec:
  - 85% occurred on CNC_02 (vs. 15% on CNC_01)
  - 70% occurred during Shift 2 (Worker_B assigned)
  - 60% correlated with Tool Wear >75%

MES Recommendation:
  1. Inspect CNC_02 calibration (possible thermal drift)
  2. Provide additional training to Worker_B
  3. Reduce tool replacement interval from 500 to 400 cycles

Player Decision: Implement all 3 → scrap rate drops from 12% to 4% within 1 week
```

---

### 3.8 Process Management

**Real-World:** Monitor processes, adjust parameters in real-time  
**In-Game:**  
- **Real-Time Process Control:**
  - MES monitors machine parameters vs. spec
  - If deviation detected → auto-adjust (if player enabled) or alert
- **Adaptive Control:**
  - Example: CNC cutting force too high → MES reduces feed rate 10%

**Adaptive Control Example (CNC Machining):**
```
Target: Cut aluminum block, target cut force: 500 N

MES monitors cutting force sensor (OPC-UA telemetry):

Time 0:00 - Force: 510 N (2% over target) → Within tolerance
Time 0:15 - Force: 530 N (6% over) → MES logs "Elevated force"
Time 0:30 - Force: 580 N (16% over) → WARNING threshold

MES Analysis:
- Tool wear estimated at 68% (from cycle count)
- Material lot: AL-6061-LOT-4523 (same as previous batches - not material issue)
- Hypothesis: Tool dulling causing increased force

MES Action (if Auto-Adjust enabled):
  - Reduce feed rate: 250 mm/min → 225 mm/min (10% reduction)
  - Result: Force drops to 520 N (4% over target - acceptable)
  - Cycle time increases 10% (trade-off: slower but safer)
  - MES flags: "Tool replacement recommended after this cycle"

Player Visibility:
- Alert notification: "CNC_02 adaptive feed reduction - tool wear suspected"
- Can override if desired (manual control)
```

---

### 3.9 Maintenance Management

**Real-World:** Preventive maintenance scheduling, CMMS integration  
**In-Game:**  
- **Preventive Maintenance (PM) Scheduling:**
  - Based on cycle count, hours run, or calendar (e.g., monthly)
  - MES suggests PM windows (low-demand periods)
- **Predictive Maintenance (PdM):**
  - Analyze vibration, temperature, tool wear trends
  - Predict failures before they occur
- **Work Orders:**
  - MES generates maintenance work orders
  - Assign to maintenance workers, track completion

**Predictive Maintenance Example:**
```
CNC_01 Vibration Trend (MES monitors accelerometer sensor):

Week 1: Avg vibration: 2.5 mm/s (baseline)
Week 2: Avg vibration: 2.7 mm/s (+8%)
Week 3: Avg vibration: 3.1 mm/s (+24%)
Week 4: Avg vibration: 3.8 mm/s (+52%) → ALERT THRESHOLD

MES Prediction Model:
- Historical data: vibration >4.0 mm/s correlates with spindle bearing failure within 48 hours
- Current rate of increase: +0.5 mm/s per week
- Estimated time to failure: 10-14 days

MES Alert (sent to player):
"CNC_01 Predictive Maintenance: Spindle bearing degradation detected
 Recommended Action: Schedule bearing replacement within 2 weeks
 Consequence if ignored: 85% probability of unplanned breakdown, 8-hour downtime, $5k emergency repair
 Proactive Maintenance Cost: $1,200 parts + 2 hours downtime"

Player Decision:
  A. Schedule PM immediately (safe, minimal disruption)
  B. Wait until end of current contract (risk: breakdown mid-production)
  C. Ignore (gambling that bearing lasts longer)

Educational Value: Teaches cost-benefit of proactive vs. reactive maintenance
```

---

### 3.10 Product Tracking and Genealogy

**Real-World:** Full traceability of materials, processes, operators for each part  
**In-Game:**  
- **Serial Number Tracking:**
  - Every part gets unique ID (auto-generated or barcode)
  - MES logs: which material lot, which machine, which worker, which date/time
- **Genealogy Database:**
  - Query: "Show me the complete history of Part SN: ENG-v2-S00523"
  - Returns: material lot, machining parameters, QC results, assembly torque values, worker IDs

**Genealogy Record Example:**
```
Part Serial Number: ENG-v2-S00523
Product: Engine Block v2
Status: In Assembly

Manufacturing History:
┌─────────────────────────────────────────────────────────────┐
│ Stage 1: Raw Material                                       │
│   Material: Aluminum 6061-T6                                │
│   Lot Number: AL-6061-LOT-4523                              │
│   Supplier: Alcoa Corp.                                     │
│   Received Date: 2025-12-15                                 │
│   QC Inspection: PASS (Certificate: AL-QC-4523-001)         │
├─────────────────────────────────────────────────────────────┤
│ Stage 2: CNC Machining (Roughing)                          │
│   Machine: CNC_02                                           │
│   Operator: Worker_Jane (ID: W-042)                         │
│   NC Program: PROG_ENG_BLK_V2_ROUGH.nc                      │
│   Start Time: 2025-12-20 08:15:32                           │
│   End Time: 2025-12-20 08:27:18                             │
│   Cycle Time: 11.77 min (vs. target 12 min - efficient!)   │
│   Spindle Speed: 2500 RPM (actual avg: 2487 RPM)            │
│   Feed Rate: 250 mm/min                                     │
│   Tool: End Mill 12mm (#EM-12-0042, wear: 58%)            │
│   QC Checkpoint: Dimensions within rough tolerance          │
├─────────────────────────────────────────────────────────────┤
│ Stage 3: CNC Machining (Finishing)                         │
│   Machine: CNC_02                                           │
│   Operator: Worker_Jane (ID: W-042)                         │
│   NC Program: PROG_ENG_BLK_V2_FINISH.nc                     │
│   Start Time: 2025-12-20 08:30:05                           │
│   End Time: 2025-12-20 08:47:23                             │
│   Cycle Time: 17.3 min                                      │
│   Tool: End Mill 6mm (#EM-06-0089, wear: 34%)              │
│   Measured Dimensions:                                      │
│     - Length: 200.02 mm (target: 200.00 ± 0.05) ✓          │
│     - Width: 150.01 mm (target: 150.00 ± 0.05) ✓           │
│     - Height: 180.00 mm (target: 180.00 ± 0.05) ✓          │
│   Surface Finish: Ra 1.2 μm (target: <2.0 μm) ✓            │
│   QC Result: PASS                                           │
├─────────────────────────────────────────────────────────────┤
│ Stage 4: Assembly (Cylinder Head Bolting) - IN PROGRESS    │
│   Station: Assembly_03                                      │
│   Operator: Worker_Carlos (ID: W-018)                       │
│   Start Time: 2025-12-20 09:05:11                           │
│   Tool: Atlas Nutrunner #2                                  │
│   Torque Values (target: 85 Nm ± 1 Nm):                    │
│     - Bolt A1: 85.2 Nm, 59° ✓                              │
│     - Bolt A2: 84.8 Nm, 60° ✓                              │
│     - Bolt A3: 85.1 Nm, 61° ✓                              │
│     - Bolt A4: [Pending]                                    │
└─────────────────────────────────────────────────────────────┘

Traceability Uses:
1. Customer audit: "Prove this engine was assembled to spec"
2. Recall management: "Material lot AL-6061-LOT-4523 defective → identify all affected parts"
3. Quality investigation: "Why did 5 parts from this batch fail? Compare genealogy records"
4. Continuous improvement: "Worker_Jane consistently achieves 98% efficiency - what's her technique?"
```

**Recall Scenario (Gameplay Event):**
```
Event: "Material Recall - Lot AL-6061-LOT-4523"
Supplier notification: Batch AL-6061-LOT-4523 failed post-delivery testing - porosity defects

MES Query:
SELECT parts WHERE materialLot = "AL-6061-LOT-4523" AND status IN ("In Production", "Finished", "Shipped")

Results:
- 23 parts in production → HALT immediately, scrap
- 47 parts in finished goods → QUARANTINE, inspect
- 12 parts shipped to customers → RECALL (notify customers, arrange return)

Player Impact:
- Immediate cost: 23 scrapped parts × $200 material = $4,600
- Inspection cost: 47 × $50 = $2,350
- Recall cost: 12 × $500 logistics = $6,000
- Total: $12,950 + reputation hit

MES Value: Without genealogy tracking, player would have no way to identify affected parts - could ship defective products, catastrophic warranty claims
```

---

### 3.11 Performance Analysis

**Real-World:** Calculate OEE, throughput, cost per unit, trend analysis  
**In-Game:**  
- **KPI Dashboard:**
  - OEE (Overall Equipment Effectiveness)
  - Throughput (units per hour)
  - First Pass Yield (% passing QC on first attempt)
  - MTBF (Mean Time Between Failures)
  - MTTR (Mean Time To Repair)
- **Historical Trending:**
  - Compare this week vs. last week, this month vs. last month
  - Identify seasonality, improvement trends
- **Cost Analysis:**
  - Cost per unit (materials + labor + overhead)
  - Scrap cost
  - Downtime cost (lost opportunity)

**OEE Calculation (Detailed Example):**
```
Shift Summary: 8-hour shift (480 minutes)

Planned Downtime:
- Scheduled breaks: 30 min
- Shift changeover: 15 min
- Planned maintenance: 0 min
Planned Production Time = 480 - 45 = 435 min

Unplanned Downtime:
- Machine setup (new work order): 25 min
- Material shortage delay: 10 min
- Breakdown (tool change): 8 min
Operating Time = 435 - 43 = 392 min

Availability = Operating Time / Planned Production Time
            = 392 / 435 = 90.1%

Theoretical Max Output:
- Target cycle time: 12 min/part
- Max parts in 392 min = 392 / 12 = 32.67 parts (round to 32)

Actual Output:
- Parts produced: 29 parts

Performance = Actual Output / Theoretical Max Output
           = 29 / 32 = 90.6%

Quality:
- Parts produced: 29
- Parts passed QC: 28
- Parts scrapped: 1

Quality = Good Parts / Total Parts
       = 28 / 29 = 96.6%

OEE = Availability × Performance × Quality
    = 0.901 × 0.906 × 0.966
    = 78.8%

Interpretation:
- World-class OEE: >85%
- Industry average: 60-75%
- This shift: 78.8% → Good, but room for improvement

MES Breakdown Analysis:
Primary Loss: Availability (90.1% → target 95%)
  - Setup time too long (25 min → target 15 min)
  - Suggestion: Implement SMED (Single-Minute Exchange of Dies) techniques
  - Potential improvement: +5% Availability → OEE +3.9% → 82.7%

Secondary Loss: Quality (96.6% → target 99%)
  - 1 scrapped part (3.4% scrap rate → target 1%)
  - Root cause: Tool wear >80% during cycle
  - Suggestion: Replace tools at 70% wear (proactive)
```

---

## 4. MES Scripting System (Player-Facing)

### 4.1 Tiered Complexity (Progressive Depth)

**Tier 0: No MES (Tutorial/Beginner)**
- Machines run with default parameters
- No automation
- Player manually starts/stops each machine
- Achieves ~70% potential efficiency

**Tier 1: GUI Presets (Casual)**
- Dropdown menus for common scenarios:
  - "High Speed / Low Precision"
  - "Balanced"
  - "High Precision / Low Speed"
- MES applies preset parameters to machines
- Achieves ~85% potential efficiency

**Tier 2: Block-Based Logic (Strategic)**
- Visual programming (like Scratch or Blockly)
- Drag-and-drop IF-THEN-ELSE blocks
- Example:
  ```
  [IF] [Part.version] [==] [2]
  [THEN] [Set] [Nutrunner.torque] [=] [95]
  [ELSE] [Set] [Nutrunner.torque] [=] [85]
  ```
- Achieves ~95% potential efficiency

**Tier 3: Text-Based Scripting (Expert)**
- Lua-like syntax (or simplified pseudo-code)
- Full access to machine states, sensor data, historical trends
- Example:
  ```lua
  function onPartArrive(part)
    if part.version >= 2 then
      if getCurrentTool().wear > 0.7 then
        scheduleMaintenance("Tool replacement needed")
        machine.feedRate = machine.feedRate * 0.9  -- Compensate for wear
      end
      applyTorqueProfile("precision_v2")
    else
      applyTorqueProfile("standard")
    end
    
    -- Predictive quality adjustment
    if getRecentScrapRate() > 0.05 then
      machine.qcSampleRate = 0.20  -- Increase QC to 20% until issue resolved
    end
  end
  ```
- Achieves 100-110% potential efficiency (exceeds baseline via optimization)

---

### 4.2 MES Block Editor (Tier 2 Detailed Design)

**UI Layout:**
```
┌──────────────────────────────────────────────────────────────┐
│ MES RULE EDITOR                                    [Simulate] │
├──────────────┬───────────────────────────────────────────────┤
│ BLOCKS       │ WORKSPACE                                     │
│              │                                               │
│ ┌──────────┐│  [START: When Part Arrives]                  │
│ │ Triggers ││    ↓                                          │
│ ├──────────┤│  [IF] [Part.version] [>=] [2]                │
│ │ Conditions││    ↓ TRUE                                    │
│ ├──────────┤│    [SET] [Machine.torque] = [95]             │
│ │ Actions  ││    [SET] [QC.sampleRate] = [0.10]            │
│ ├──────────┤│    [LOG] "High-precision part detected"      │
│ │ Math     ││    ↓                                          │
│ ├──────────┤│  [ELSE]                                       │
│ │ Variables││    ↓ FALSE                                    │
│ ├──────────┤│    [SET] [Machine.torque] = [85]             │
│ │ Advanced ││    [SET] [QC.sampleRate] = [0.05]            │
│ └──────────┘│    ↓                                          │
│              │  [SEND PART TO] [Next Station]               │
│              │                                               │
│              │  [Estimated Efficiency Gain: +12%]           │
│              │  [Scrap Rate Reduction: -8%]                 │
└──────────────┴───────────────────────────────────────────────┘
```

**Block Categories:**

**1. Triggers (When to execute rule):**
- When part arrives at station
- When machine state changes (idle → running)
- When QC detects defect
- When buffer reaches X% full
- Every X cycles
- On schedule (time-based)

**2. Conditions (IF statements):**
- Part properties: version, material, size, customer
- Machine state: status, tool wear, cycle count, temperature
- QC data: recent scrap rate, trend direction
- Worker: skill level, fatigue, specialty match
- Inventory: material availability, buffer occupancy
- Time: shift, day of week, rush order deadline proximity

**3. Actions (THEN do this):**
- Set machine parameter (torque, speed, feed, coolant)
- Adjust quality sampling rate
- Reroute part (if AGVs available)
- Send alert to player
- Log event
- Schedule maintenance
- Pause production
- Adjust worker assignment (if multi-skilled workers available)

**4. Math & Logic:**
- Arithmetic: +, -, *, /, %
- Comparison: ==, !=, <, >, <=, >=
- Boolean: AND, OR, NOT
- Functions: AVG(), MAX(), MIN(), TREND() (for SPC)

**5. Variables (Store data):**
- Create custom variables: defectCount, lastMaintenanceDate
- Use in calculations or conditions

**6. Advanced (Tier 3 preview):**
- Loops (REPEAT X times, WHILE condition)
- Sub-routines (call reusable functions)
- API calls (future: export data, trigger external systems)

---

### 4.3 MES Simulation Mode

**Purpose:** Test MES rules without affecting real production (risk-free experimentation)

**How It Works:**
1. Player creates/edits MES rule
2. Clicks "Simulate"
3. Game runs virtual production scenario:
   - Simulates 100 parts (or player-defined number)
   - Uses historical data (recent machine performance, scrap rates)
   - Applies player's MES rule
   - Compares outcome vs. baseline (no rule)
4. Displays results:
   - Throughput: +X parts/hour
   - Scrap rate: -Y%
   - Cycle time: +/- Z seconds average
   - Cost impact: $W saved/spent
   - OEE change: +/- %

**Simulation Report Example:**
```
SIMULATION RESULTS: "V2 Precision Torque Rule"

Scenario: 100 parts (v1: 60, v2: 40)
Baseline (No Rule):
  - Avg Cycle Time: 12.5 min
  - Scrap Rate: 6.2% (v1: 3%, v2: 11% due to wrong torque)
  - OEE: 72%

With MES Rule:
  - Avg Cycle Time: 12.3 min (2% faster - less rework)
  - Scrap Rate: 3.8% (v1: 3%, v2: 5% - improved!)
  - OEE: 79% (+7 percentage points)

Financial Impact (per 100 parts):
  - Scrap Cost Saved: 2.4 parts × $150 = $360
  - Time Saved: 0.2 min/part × 100 = 20 min = ~1.5 extra parts worth $225
  - Total Value: $585 per 100 parts

Recommendation: DEPLOY THIS RULE
Risk Level: LOW (minimal cycle time impact, significant quality benefit)
```

**Player Decision:**
- Deploy immediately
- Tweak rule further (adjust torque value, test again)
- Save for later
- Discard

---

## 5. Multi-Product / Mixed-Model Production (Advanced MES)

### 5.1 Challenges of Multi-Product Lines

**Real-World Problem:**  
Producing Engine v1, v2, v3 on same line introduces:
- **Setup/Changeover Time:** Changing tools, parameters between variants
- **Part Proliferation:** 3× as many components to manage
- **Worker Complexity:** Must remember 3 different assembly sequences
- **Quality Risk:** Easy to use wrong spec for wrong variant

**Without MES:**
- Batch production (make all v1, then all v2, then all v3)
- Large changeovers (30-60 min between batches)
- High WIP (store 1 week of v1 inventory while making v2)

**With MES:**
- Mixed-model sequencing (v1, v2, v3, v1, v2, v3...)
- Zero or near-zero changeover (MES auto-configures machines per part)
- Low WIP (produce to demand in real-time)

---

### 5.2 MES-Enabled Mixed-Model Production

**Scenario:** Line producing 3 engine variants

**Part Tagging (RFID or Barcode):**
- Each part carries ID: "ENG-v1-S00145", "ENG-v2-S00087"
- RFID readers at each station read tag as part arrives
- MES looks up part number → retrieves production recipe

**Station-by-Station MES Configuration:**

**Station 1: CNC Machining**
```
MES Rule:
ON PartArrive(partID)
  product = lookupProduct(partID)  // e.g., "v1", "v2", or "v3"
  
  SWITCH product
    CASE "v1":
      loadNCProgram("PROG_V1.nc")
      setSpindleSpeed(2500)
      setFeedRate(250)
    CASE "v2":
      loadNCProgram("PROG_V2.nc")
      setSpindleSpeed(2200)  // v2 requires tighter tolerance, slower
      setFeedRate(220)
    CASE "v3":
      loadNCProgram("PROG_V3.nc")
      setSpindleSpeed(2800)  // v3 is simpler, faster
      setFeedRate(280)
  END_SWITCH
  
  startMachining()
END
```

**Station 2: Assembly (Atlas Nutrunner)**
```
MES Rule:
ON PartArrive(partID)
  product = lookupProduct(partID)
  
  SWITCH product
    CASE "v1":
      nutrunner.setTorque(75, tolerance=3)
      boltSequence = [A1, A2, A3, A4]  // Simple 4-bolt pattern
    CASE "v2":
      nutrunner.setTorque(85, tolerance=1.5)
      boltSequence = [A1, A4, A2, A3]  // Cross-pattern for v2
    CASE "v3":
      nutrunner.setTorque(95, tolerance=1, angle=60)
      boltSequence = [A1, A4, A2, A3, A5, A6]  // 6-bolt pattern, torque+angle
  END_SWITCH
  
  displayInstructions(worker, boltSequence)  // Show HMI diagram
  enforceSequence(boltSequence)  // MES locks out-of-order bolts
END
```

**Station 3: QC**
```
MES Rule:
ON PartArrive(partID)
  product = lookupProduct(partID)
  
  toleranceSpec = lookupTolerances(product)  // Different specs per variant
  
  SWITCH product
    CASE "v1":
      qc.checkDimensions(toleranceSpec_v1)  // ±0.05mm
      qc.sampleRate = 0.05  // 5% sampling (mature product)
    CASE "v2":
      qc.checkDimensions(toleranceSpec_v2)  // ±0.02mm (tighter)
      qc.sampleRate = 0.10  // 10% (newer, needs more monitoring)
    CASE "v3":
      qc.checkDimensions(toleranceSpec_v3)  // ±0.01mm (ultra-precision)
      qc.sampleRate = 0.20  // 20% (highest scrutiny)
      qc.functionalTest("PressureTest", minPressure=150, maxPressure=200)  // v3 only
  END_SWITCH
END
```

---

### 5.3 Sequencing Strategy

**Goal:** Minimize changeover time, balance workload across stations

**Strategy A: Batching (Traditional)**
```
Schedule: 50× v1, 50× v2, 50× v3, REPEAT

Changeover Times:
- v1 → v2: 15 min (parameter changes, tool swap)
- v2 → v3: 20 min (more complex setup)
- v3 → v1: 15 min

Total Changeover per Cycle: 50 min per 150 parts = 0.33 min/part overhead
Throughput: Reduced by 3%
```

**Strategy B: Mixed-Model with MES (Toyota-Style)**
```
Schedule: v1, v2, v3, v1, v2, v3... (repeated pattern)

Changeover Times with MES Auto-Config:
- Per part: 5 seconds (RFID read + MES parameter load)
- Effectively zero (happens while part in transit on conveyor)

Total Changeover: 0 min (absorbed into cycle time)
Throughput: No reduction
WIP: 90% lower (produce exactly to demand)
```

**Why MES Matters:**
- **Before MES:** Worker must remember "Now I'm making v2, use 85 Nm torque"
- **With MES:** Worker sees HMI display auto-update "Part v2 detected - torque set to 85 Nm"
- **Benefit:** Zero cognitive load on worker, zero chance of error

---

### 5.4 Part Proliferation Management

**Problem:** 3 engine variants → 3× components to stock

**Example:**
- v1 uses Bolt Type A (M10)
- v2 uses Bolt Type B (M12)
- v3 uses Bolt Type C (M14)

**Traditional Approach:**
- Stock all 3 bolt types at every assembly station
- Risk: Worker grabs wrong bolt → defect

**MES Solution: Smart Kanban**
```
Assembly Station has electronic kanban bin:
- Bin has RFID reader
- MES knows next part coming is v2
- Bin light indicator:
  - Compartment A (M10): RED (not needed)
  - Compartment B (M12): GREEN (pick this one)
  - Compartment C (M14): RED (not needed)

Worker sees green light → picks M12 → impossible to grab wrong bolt

If wrong compartment opened, MES alerts: "ERROR: Wrong bolt type selected"
```

---

### 5.5 Functional Example (Full Mixed-Model Shift)

**Scenario:** 8-hour shift, produce 60 parts (20× v1, 25× v2, 15× v3)

**Sequence (MES-Optimized):**
```
Pattern: v1, v2, v3, v1, v2, v1, v2, v3, ... (balances workload)

Part Flow:
08:00 - Part #1 (v1) arrives at CNC
  - RFID scanned
  - MES loads PROG_V1.nc, 2500 RPM
  - Machining: 10 min
  
08:10 - Part #1 to Assembly, Part #2 (v2) arrives at CNC
  - CNC auto-switches to PROG_V2.nc, 2200 RPM (5 sec changeover)
  - Assembly: Worker sees HMI "v1: Bolt pattern A1-A2-A3-A4, 75 Nm"
  
08:15 - Part #1 to QC, Part #2 to Assembly, Part #3 (v3) to CNC
  - QC: 5% sampling (v1) → passes, to Dispatch
  - Assembly: HMI updates "v2: Cross pattern, 85 Nm"
  - CNC: Switches to PROG_V3.nc, 2800 RPM
  
... continues seamlessly for 60 parts

Results:
- Total Production Time: 470 min (480 min shift - 10 min breaks)
- Avg Cycle Time: 7.8 min/part (includes all stations)
- Changeover Time: 0 min (MES handles automatically)
- Scrap: 2 parts (3.3% rate - acceptable)
- OEE: 82%

Without MES (batched production):
- Changeover: 50 min lost
- Avg Cycle Time: 8.2 min/part (setup delays)
- Scrap: 5 parts (8.3% - worker errors on variant changes)
- OEE: 68%

Improvement: +14 percentage point OEE, +12% throughput
```

---

## 6. Advanced Topics (Phase 4-5 Content)

### 6.1 Digital Twin Integration

**Concept:** Virtual replica of physical factory

**Implementation:**
- MES sends all production data to simulation engine
- Simulation runs in parallel, predicts outcomes
- Player can test "what-if" scenarios:
  - "What if I add a 3rd CNC?"
  - "What if contract volume increases 50%?"
- Digital twin shows predicted throughput, bottlenecks, costs

**Gameplay Value:**
- Risk-free experimentation
- Validate expensive capex decisions before spending
- Training tool (learn MES scripting in safe environment)

---

### 6.2 AI-Assisted MES (Tier 5 Unlock)

**Concept:** MES learns from player's factory, suggests optimizations

**Examples:**
- "AI detected: CNC_02 slower than CNC_01 despite same model. Suggest calibration check."
- "AI optimization: Rearranging production sequence (v3 → v1 → v2) reduces setup time 18%"
- "AI prediction: Based on current scrap trend, recommend tool replacement in 2 hours"

**Implementation (Simplified ML):**
- Historical data analysis (correlations)
- Pattern matching (detect anomalies)
- Optimization algorithms (genetic algorithm for sequencing)

**Balance:** AI provides suggestions, player makes final decision (keeps player agency)

---

## 7. MES UI/UX Design

### 7.1 MES Dashboard (Main View)

```
┌──────────────────────────────────────────────────────────────┐
│ MES CONTROL CENTER                          [Help] [Settings]│
├──────────────────────────────────────────────────────────────┤
│ ┌─ PRODUCTION STATUS ───────────┐ ┌─ ALERTS ──────────────┐ │
│ │ Line 1: RUNNING (78% OEE)    │ │ ⚠ CNC_02 tool wear 75%│ │
│ │   Machine: CNC_02, Lathe_01   │ │ ⚠ Buffer A 85% full   │ │
│ │   Current: Engine v2 (15/50)  │ │ ✓ QC: All pass (2h)   │ │
│ │   ETA: 2.3 hours              │ │                       │ │
│ │ [Details] [Adjust]            │ │ [View All]            │ │
│ └───────────────────────────────┘ └───────────────────────┘ │
├──────────────────────────────────────────────────────────────┤
│ ┌─ ACTIVE RULES ────────────────┐ ┌─ PERFORMANCE ─────────┐ │
│ │ ✓ V2 Precision Torque        │ │ Throughput: 7.2/hr    │ │
│ │ ✓ Auto QC Sampling           │ │ Scrap Rate: 2.8%      │ │
│ │ ✗ Predictive Maintenance     │ │ Downtime: 12 min (3%) │ │
│ │   (Tier 4 locked)             │ │ Cost/Unit: $142       │ │
│ │ [Add Rule] [Edit]             │ │ [Analytics]           │ │
│ └───────────────────────────────┘ └───────────────────────┘ │
├──────────────────────────────────────────────────────────────┤
│ ┌─ MACHINE GRID ─────────────────────────────────────────┐  │
│ │ [CNC_01: IDLE]  [CNC_02: RUN ●] [Lathe_01: SETUP]     │  │
│ │ [Assy_01: RUN]  [QC_01: RUN]   [Buffer_A: 85% ▲]      │  │
│ │ [Dispatch: OK]                                          │  │
│ └─────────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────────┘
```

---

## 8. Summary & Gameplay Integration

**What Makes This MES System Work:**
1. **Authentic but Accessible:** Real concepts (OPC-UA, ISA-95) abstracted for fun
2. **Progressive Complexity:** Tier 0-5 ensures all players can engage at their level
3. **Meaningful Rewards:** MES mastery = higher OEE = more profit = strategic advantage
4. **Educational:** Players learn real manufacturing principles while playing
5. **Interconnected:** MES touches every system (machines, workers, quality, planning, contracts)

**Key Takeaway for Implementation:**
- Start with **Tier 0-1** (MVP: GUI presets, basic automation)
- Add **Tier 2** (block editor) in Phase 3
- Tier 3-5 are post-launch content
- Always show player the "why" (efficiency gains, cost savings) to motivate MES usage

---

**END OF MES TECHNICAL ADDENDUM**

**Next Steps:**
1. Review this addendum for accuracy and gameplay fit
2. Integrate concepts into main GDD Section 3
3. Create similar addendums for:
   - PLM/BOM/Process Routing (expand Section 4B)
   - Mixed-Model Production Strategies
   - Quality Management (SPC, root cause analysis)
