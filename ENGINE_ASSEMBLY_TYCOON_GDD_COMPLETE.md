# ENGINE ASSEMBLY TYCOON
## Complete Game Design Document v2.0
### Production-Ready Edition

**Document Version:** 2.0.0  
**Last Updated:** December 2024  
**Status:** Ready for Development  
**Target Platform:** PC (Steam Early Access)  
**Genre:** Strategic Simulation, Management, Tycoon  
**Development Approach:** MVP → Modular Expansion

---

## TABLE OF CONTENTS

### PART A: GAME DESIGN
1. Executive Summary & Core Gameplay Overview
2. Factory Systems (Machines, Workers, Conveyors)
3. MES System (Manufacturing Execution System)
4. PLM (Product Lifecycle Management)
4B. Product Structure, BOM & Process Routing
5. R&D & Customer Contracts
6. Planning & Capacity Management
7. Research & Technology Tree
8. UI/UX Design (EXPANDED)
9. Challenges & Advanced Gameplay
10. Game Progression & Endgame
11. Complete Game Flow & Event System
12. System Integration Summary

### PART B: TECHNICAL SPECIFICATIONS (NEW)
13. Technical Architecture & Data Design
14. Economy Balance & Tuning Parameters
15. Audio Design (NEW)
16. Narrative & Flavor Elements (NEW)
17. QA & Testing Strategy (NEW)
18. Accessibility & Localization (NEW)

### PART C: PRODUCTION ROADMAP
19. MVP Definition & Scope
20. Development Phases & Milestones
21. Asset Production Pipeline
22. Launch Strategy

---

# PART A: GAME DESIGN

# 1. EXECUTIVE SUMMARY & CORE GAMEPLAY OVERVIEW

## 1.1 Game Vision

Engine Assembly Tycoon is a **top-down 2D strategic simulation and management game** where players assume the role of a production engineering department manager in a company that manufactures engines for cars and industrial applications.

**One-Sentence Pitch:**  
*"Build, optimize, and automate complex production lines while balancing quality, cost, and customer satisfaction in a realistic factory simulation."*

The game merges **real-world engineering practices** with **fun and engaging strategic gameplay**, allowing both casual players and advanced simulation enthusiasts to enjoy the game at their own level:

- **Casual players** focus on basic production lines, R&D, and customer contracts without needing to touch MES logic or advanced planning.
- **Advanced players** dive into MES coding, detailed production line optimization, multi-line planning, and complex contract management, gaining significant efficiency and reward advantages.

### Core Concept
Players build, optimize, and expand production lines while balancing:
- Quality (scrap rate, QC compliance)
- Cost (materials, labor, maintenance)
- Throughput (units per shift/week)
- Workforce efficiency (skills, fatigue, training)
- R&D (new products, improvements)
- Customer satisfaction (deadlines, contract terms)
- Supply chain logistics (material availability, costs)

### Unique Selling Points (USPs)

1. **Real-World Manufacturing Systems**
   - Atlas Nutrunners (precision torque tools)
   - MES/PLM/ERP systems (industry-standard)
   - Part lifecycle management (ECOs, versioning, phase-outs)

2. **Optional Depth Philosophy**
   - MES coding and advanced automation provide strategic complexity
   - BUT: completely optional - GUI presets enable casual play
   - No feature is mandatory, but mastery is rewarded

3. **Integrated Business Strategy**
   - Acquire customers through reputation and marketing
   - Choose contract types: OEM manufacturing, co-development, or in-house products
   - Long-term strategic decisions affect company growth

4. **Multi-Layered Economy**
   - Realistic cost structures (capex, opex, labor, materials)
   - Multiple revenue streams (contracts, ongoing sales, bonuses)
   - Gradual progression from small shop to global operations

5. **Expandable Late-Game Content** (Post-MVP)
   - Multi-factory global operations
   - AI-driven optimization
   - Digital twin simulation
   - Workshop integration (share MES scripts, factory layouts)

---

## 1.2 Target Audience

### Primary Audience
**Strategic simulation enthusiasts, ages 18-45**
- Interests: Factory games (Factorio, Satisfactory), management sims (SimCity, RimWorld)
- Values: Systems mastery, optimization, long-term planning
- Platform: PC (Steam), keyboard + mouse primary input

### Secondary Audience
**Casual tycoon players, ages 25-50**
- Interests: Business sims (Game Dev Tycoon, Two Point Hospital)
- Values: Progression, achievement, creative problem-solving
- Platform: PC (Steam), potential laptop players

### Tertiary Audience
**Engineering professionals and enthusiasts**
- Interests: Real-world manufacturing, industry 4.0, automation
- Values: Authenticity, technical accuracy, professional simulation
- Platform: PC (Steam), may seek educational value

### Anti-Audience (Not Targeting)
- Action/twitch gameplay fans (too slow-paced)
- Mobile casual gamers (too complex for mobile)
- Extreme hardcore sim fans (not DCS-level realism)

---

### Player Personas

#### Persona 1: "The Casual Tycoon" (40% of players)
**Demographics:** Alex, 28, accountant, plays 5-10 hours/week  
**Goals:** Relax after work, watch numbers go up, achieve goals  
**Playstyle:**
- Uses GUI presets for everything
- Focuses on revenue and simple contracts
- Avoids MES coding entirely
- Enjoys unlocking new machines and growing the factory visually

**Design Priorities for Alex:**
- Clear tutorial explaining basics
- Suggested production schedules
- Visual feedback (animations, progress bars)
- Satisfying progression (frequent small wins)

---

#### Persona 2: "The Strategist" (35% of players)
**Demographics:** Jamie, 34, project manager, plays 10-20 hours/week  
**Goals:** Master systems, optimize efficiency, beat challenges  
**Playstyle:**
- Uses planning tools extensively
- Experiments with MES presets and basic scripting
- Manages multiple contracts simultaneously
- Seeks efficiency bonuses and high scores

**Design Priorities for Jamie:**
- Rich analytics dashboard
- Clear cause-effect relationships
- Challenge system with leaderboards
- Meaningful optimization opportunities

---

#### Persona 3: "The Engineer" (20% of players)
**Demographics:** Morgan, 42, software engineer, plays 15-30 hours/week  
**Goals:** Full mastery, perfect automation, creative solutions  
**Playstyle:**
- Writes complex MES scripts
- Optimizes every parameter
- Builds elaborate multi-line layouts
- Shares factory designs with community

**Design Priorities for Morgan:**
- Deep MES scripting tools
- Advanced analytics and simulation
- Moddability and extensibility
- Community features (workshop support)

---

#### Persona 4: "The Business Developer" (5% of players)
**Demographics:** Sam, 38, MBA, plays 8-15 hours/week  
**Goals:** Strategic empire building, long-term planning  
**Playstyle:**
- Focuses on R&D and customer relationships
- Negotiates contracts aggressively
- Plans multi-quarter strategies
- Builds diverse product portfolio

**Design Priorities for Sam:**
- Contract negotiation depth
- R&D strategy layer
- Long-term planning tools
- Global expansion systems (post-launch)

---

## 1.3 Core Gameplay Pillars

### Pillar 1: Factory Layout & Production Line Optimization

**Description:**  
Players design and continuously refine factory floor layouts by placing machines, conveyors, buffers, and assembly stations on a grid-based canvas.

**Mechanics:**
- **Grid-based placement:** 64x64px cells (1m² equivalent)
- **Machine connections:** Input/output ports must align with conveyors
- **Buffer management:** Queue sizes affect throughput and backlog
- **Bottleneck identification:** Visual heatmaps show slow points
- **Layout iteration:** Easy to reconfigure (low cost early, higher cost later)

**Functional Integration:**
- Production lines interact with MES (machine parameters)
- PLM system (part versions affect machine requirements)
- ERP (material flow, inventory tracking)
- R&D (new machines unlock new layouts)

**Example Scenario:**
- **Setup:** Player assigns high-volume engine line to 3 machines: Lathe → CNC → Assembly
- **Problem:** CNC becomes bottleneck (8 parts/min vs Lathe 10 parts/min)
- **Solution Options:**
  1. Add second CNC (costs $25k, doubles capacity)
  2. Optimize MES torque profile (reduces cycle time 10%, free but requires skill)
  3. Assign higher-skilled worker to CNC (improves efficiency 15%)
- **Result:** Choosing option 2+3 achieves 23% improvement at no cost, demonstrating mastery

---

### Pillar 2: Workforce & Skills Management

**Description:**  
Workers are not just numbers - they have skills, fatigue, specializations, and progression paths that meaningfully affect production outcomes.

**Mechanics:**
- **Skill System:** 1-100 scale across specializations (Machining, Assembly, QC, R&D)
- **Fatigue Management:** 0-100 scale, accumulates per shift, affects efficiency and error rate
- **Experience Progression:** +1 skill per 100 cycles worked on specialized tasks
- **Certifications:** Unlockable training (MES coding, advanced assembly, safety) enables new capabilities
- **Assignment Strategy:** Wrong worker = lower efficiency, right worker = bonus

**Worker Attributes:**

| Attribute | Range | Impact |
|-----------|-------|--------|
| Skill | 1-100 | Cycle time multiplier (0.7x - 1.3x) |
| Specialization | 5 types | +15% efficiency on matched tasks |
| Fatigue | 0-100 | >50 = slower work, >75 = errors increase |
| Experience | Levels | Reduces setup time, unlocks certifications |
| Salary | $2.5k-$6k/mo | Higher skill = higher cost |

**Functional Integration:**
- MES can assign tasks based on worker skill availability
- Planning system schedules shifts to manage fatigue
- R&D requires skilled engineers (separate from production workers)
- Contracts may require certified workers (e.g., safety-critical assembly)

**Example Scenario:**
- **Situation:** Player has 2 assembly stations, 3 workers (skills: 45, 70, 85)
- **Assignment A (naive):** Assign randomly → average efficiency 1.0x
- **Assignment B (optimized):** Skill-85 on critical Atlas Nutrunner task, others on simpler tasks → 1.15x efficiency on critical path
- **Impact:** Option B reduces scrap 12%, increases throughput 8%

---

### Pillar 3: Machine Parameter Control & Optional MES Coding

**Description:**  
Players adjust machine parameters (torque, speed, feed rate) using either GUI sliders or optional MES scripting for advanced automation.

**Tier 1: Basic Parameter Adjustment (MVP)**
- GUI sliders for torque, speed, feed rate
- Preset templates: "High Speed Low Precision" / "High Precision Low Speed"
- Real-time impact preview (estimated scrap rate, cycle time)

**Tier 2: Conditional MES Rules (Post-MVP)**
- Block-based visual logic (IF-THEN-ELSE)
- Example: "IF Part.version = 2 THEN Torque = 95Nm ELSE Torque = 85Nm"
- Template library (community-shared rules)

**Tier 3: Advanced MES Scripting (Late-Game)**
- Text-based Lua scripting (for power users)
- Access to all machine states, sensor data, QC feedback
- Simulation mode (test scripts before deploying)

**Key Parameters:**

| Parameter | Machine Types | Impact |
|-----------|---------------|--------|
| Torque | Atlas Nutrunners, Assembly | Too low = loose bolts, too high = stripped threads |
| Speed (RPM) | Lathe, CNC | Higher = faster cycles but more tool wear |
| Feed Rate | CNC, Lathe | Affects cut quality and cycle time |
| Cycle Time | All | Direct throughput impact |

**Functional Example (MES Impact):**
```
// Without MES scripting
Lathe produces Part v1: 10s cycle, 5% scrap
Player manually adjusts when v2 arrives

// With basic MES rule (block-based)
IF Part.version >= 2 THEN
  Machine.feedRate = 0.12  // Slower for tighter tolerance
  Machine.qcInterval = 10   // Check every 10th part
END
Result: Auto-adjusts, scrap drops to 3%, no manual intervention

// With advanced MES (Lua script)
function onPartArrive(part)
  if part.version >= 2 and machine.tool_wear > 0.7 then
    scheduleMaintenance()
    reduceSpeed(0.9)
  end
end
Result: Predictive maintenance, prevents scrap spikes
```

**Player Choice:**
- **Casual:** Never touch MES, use presets → achieves ~85% theoretical max efficiency
- **Strategic:** Use block-based rules → achieves ~95% efficiency
- **Engineer:** Custom Lua scripts → achieves 100%+ efficiency (beyond base parameters)

---

### Pillar 4: PLM (Part Lifecycle Management)

**Description:**  
Parts have lifecycles: introduction, revision, maturity, phase-out. Players must adapt production to handle multiple versions, ECOs (Engineering Change Orders), and inventory transitions.

**Part Lifecycle Stages:**

1. **Concept/R&D** (not producible)
   - Part designed in R&D module
   - Requires time, budget, engineer allocation
   - Success probability affects quality of initial specs

2. **Introduction** (production begins)
   - New BOM (Bill of Materials) and routing created
   - MES recipes auto-generated (editable by player)
   - Worker training may be required
   - Initial production ramp-up (lower efficiency first weeks)

3. **Revision/ECO** (changes required)
   - Triggered by: customer request, QC failures, efficiency improvements
   - Player receives ECO notice with deadline
   - Must update: MES rules, machine parameters, worker training
   - Failure to implement = scrap spike, contract penalties

4. **Maturity** (stable production)
   - Optimized parameters, trained workers
   - Lowest scrap rates, highest efficiency
   - May require periodic maintenance/tool replacement

5. **Phase-Out** (end-of-life)
   - Customer requests final batch or part discontinued
   - Player schedules final production run
   - Inventory consumed or scrapped
   - Workers/machines reallocated

**ECO (Engineering Change Order) Example:**

```
ECO #2025-003: Crankshaft v1 → v2
Trigger: Customer request for higher durability
Changes Required:
  - Material: Forged Steel → High-Carbon Steel (+$15/unit)
  - Torque Spec: 85Nm ± 2Nm → 95Nm ± 1Nm (tighter tolerance)
  - QC: Sample rate 5% → 10% (more critical)
  - Worker Training: 4 hours per worker (2 workers = 8 hours)
Deadline: 2 weeks
Impact if ignored: Scrap rate +20%, contract breach possible

Player Actions:
1. Accept ECO (auto-update MES, schedule training)
2. Negotiate deadline extension (reputation cost)
3. Decline (lose contract, severe reputation hit)

Optimal Strategy:
- Accept immediately
- Use MES scripting to handle both v1 (old orders) and v2 (new orders) on same line
- Schedule training during low-demand shift
- Result: Smooth transition, 0% downtime, reputation gain
```

**Multi-Version Production (Advanced):**
- Same line produces v1, v2, v3 simultaneously
- MES selects correct parameters per part instance
- Buffers segregate versions to prevent mixing
- QC applies version-specific tolerances

**Integration:**
- PLM feeds MES (parameter requirements)
- R&D outputs new parts into PLM
- Contracts specify which versions required
- Planning schedules version transitions

---

### Pillar 5: ERP (Enterprise Resource Planning)

**Description:**  
Track materials, procurement, costs, inventory, and cash flow. Players must balance just-in-time delivery vs. safety stock, manage supplier relationships, and respond to market fluctuations.

**Core ERP Functions:**

**1. Inventory Management**
- **Raw Materials:** Steel, aluminum, fasteners, cutting tools
- **WIP (Work-In-Progress):** Parts on production floor
- **Finished Goods:** Completed engines awaiting shipment
- **Storage Costs:** $5/unit/month (encourages just-in-time)

**2. Procurement & Suppliers**
- **Supplier Relationships:** 3 tiers (Cheap, Reliable, Premium)
  - **Cheap Supplier:** -20% cost, +15% lead time variability, 5% defect rate
  - **Reliable Supplier:** Standard cost, predictable delivery, 1% defect rate
  - **Premium Supplier:** +15% cost, guaranteed next-day delivery, 0.1% defect rate
- **Lead Times:** 1-7 days depending on supplier and material
- **Bulk Discounts:** Order >1000 units = 10% discount

**3. Cost Tracking**
- **Fixed Costs:** Machine depreciation, facility rent (not implemented in MVP)
- **Variable Costs:** Materials, labor, utilities, maintenance
- **Scrap Costs:** Material waste + cycle time waste
- **Opportunity Costs:** Idle machines, bottlenecks

**4. Cash Flow**
- **Weekly/Monthly View:** Income statement
- **Alerts:** Low cash warnings, negative cash flow triggers bankruptcy risk
- **Credit Line** (unlockable): Borrow up to $50k at 5% interest/month

**Event System Integration:**
- **Supplier Delays:** Random 2-day delay, must reschedule production
- **Price Spikes:** Steel +30% for 1 week, affects margins
- **Bulk Order Opportunities:** Limited-time 20% discount if order >500 units

**Functional Example:**
```
Scenario: Steel Price Spike Event
- Normal steel: $50/unit
- Spike event: $65/unit (+30%) for 2 weeks
- Player's current stock: 200 units (4 days supply)

Options:
A. Buy at spike price → Pay $15 extra per unit
B. Delay production 2 weeks → Miss contract deadline (-10% reputation)
C. Switch to aluminum (if product allows) → +$30/unit but contract fulfilled
D. Buy from premium supplier at $57.50 → Split the difference

Optimal Strategy (depends on contract urgency):
- High-urgency contract: Option D (premium supplier)
- Low-urgency: Option B (delay, save money)
- Long-term thinking: Option A but renegotiate contract for cost-plus pricing
```

---

### Pillar 6: Customer Acquisition & Product Development

**Description:**  
Players actively acquire customers, negotiate contracts, and develop products through R&D. Strategic choices about contract types affect risk, reward, and long-term growth.

**Customer Acquisition Methods:**

1. **Reputation-Based (Passive)**
   - High-quality deliveries increase reputation (0-100 scale)
   - Reputation >60 = 1 new customer offer per month
   - Reputation >80 = premium customers (high-margin contracts)

2. **Marketing (Active)**
   - Spend $10k-$50k on campaigns
   - Generates 1-3 customer leads based on spend
   - Higher spend = higher-tier customers

3. **Events (Random)**
   - "Urgent Request" events offer high-reward, tight-deadline contracts
   - Trade shows (1-2 per year) provide networking opportunities
   - Competitor failures may redirect customers to player

**Contract Types:**

### A. OEM (Original Equipment Manufacturer)
**Model:** Customer provides complete design, player manufactures  
**Risk:** Low (no R&D required)  
**Margin:** 10-15% profit  
**Requirements:** Meet specs exactly, high QC standards  
**Duration:** 1-12 months  
**Example:** Produce 500 engines/month for Apex Automotive

**Strategic Value:**
- Stable cash flow
- Low upfront investment
- Builds reputation
- No IP ownership (can't resell)

---

### B. Co-Development
**Model:** Shared R&D costs and IP ownership  
**Risk:** Medium (shared investment, shared reward)  
**Margin:** 20-25% profit on initial contract + ongoing royalties  
**Requirements:** Allocate R&D engineers, meet milestones  
**Duration:** 2-6 months R&D + 6-12 months production  
**Example:** Co-develop new hybrid engine with GreenTech Motors

**Strategic Value:**
- Diversifies product portfolio
- Shares risk
- Ongoing revenue stream (royalties)
- Builds partnerships

---

### C. In-House Development
**Model:** Player funds 100% of R&D, owns 100% of IP  
**Risk:** High (full upfront cost, no guaranteed buyer)  
**Margin:** 40-60% profit + full ownership  
**Requirements:** Significant R&D investment, market research  
**Duration:** 4-12 months R&D, then sell to multiple customers  
**Example:** Develop proprietary "TurboMax 3000" and license to 5 customers

**Strategic Value:**
- Highest long-term revenue
- IP asset (can license indefinitely)
- Market differentiation
- Requires strong cash position

---

**Contract Attributes:**

| Attribute | Impact | Player Control |
|-----------|--------|----------------|
| Volume | Units required per week/month | None (fixed) |
| Deadline | Hard/soft cutoff dates | Negotiable (-5% revenue per week extension) |
| Quality | Max defect %, tolerance specs | None (fixed) |
| Payment Terms | Upfront / Milestone / On-delivery | Negotiable (upfront costs -10% margin) |
| Exclusivity | Can't sell to competitors | Negotiable (+15% revenue if accepted) |
| Penalties | Late delivery, QC failures | Negotiable (lower penalties = lower base pay) |

**Functional Example (Contract Negotiation):**

```
Offer: "Apex Automotive OEM Contract"
Base Terms:
- Volume: 500 engines/month
- Deadline: 6 months
- Quality: Max 3% defect rate
- Payment: 50% upfront, 50% on delivery
- Revenue: $250,000 total
- Penalty: -$5k per week late, -$10k per % over defect limit

Negotiation Options:
A. Accept as-is
B. Request 8-month timeline (+2 months) → Revenue drops to $237,500 (-5%)
C. Request 100% upfront payment → Revenue drops to $225,000 (-10%)
D. Offer exclusivity (won't work with competitors) → Revenue increases to $287,500 (+15%)
E. Counter-propose lower penalties → Base revenue drops to $230,000 but max penalty capped at -$15k total

Strategic Analysis:
- Current capacity: 400 engines/month (need to expand or lose contract)
- Cash on hand: $75,000 (50% upfront = $125k, helps fund expansion)
- Risk: Medium (can meet 500/mo with 1 new machine + worker)
- Recommendation: Accept Option A, invest $40k in new CNC + worker ($3.5k/mo), achieve 520/mo capacity
```

---

### Pillar 7: Planning & Capacity Management

**Description:**  
Strategic allocation of production lines, worker shifts, and machine schedules to meet contract demands while optimizing efficiency.

**Core Planning Functions:**

**1. Production Scheduling**
- **Line Assignment:** Which products on which lines
- **Shift Planning:** 1-3 shifts per day (8h, 16h, 24h operation)
- **Worker Allocation:** Assign workers to machines per shift
- **Material Ordering:** Schedule procurement based on production plan

**2. Capacity Calculation**

Formula:
```
LineCapacity = MIN(
  Machine1.Output,
  Machine2.Output,
  ...
  MachineN.Output
) × WorkerEfficiency × MESBonus

Where:
Machine.Output = (3600 / CycleTime) × UptimePercent
WorkerEfficiency = 0.7 to 1.3 (based on skill + fatigue)
MESBonus = 1.0 to 1.25 (if optimized scripts used)
```

**3. Bottleneck Management**

Visual Systems:
- **Heatmap Overlay:** Red = bottleneck, Yellow = warning, Green = optimal
- **Throughput Graph:** Real-time parts/hour per machine
- **Buffer Occupancy:** Shows queues backing up

Resolution Strategies:
1. **Add Parallel Machine:** Doubles capacity at bottleneck (high cost)
2. **Optimize Bottleneck:** Improve parameters, assign better worker (medium cost)
3. **Slow Upstream:** Reduce input to match bottleneck (free, suboptimal)
4. **Reroute with AGVs:** Use secondary line (requires tech unlock)

**4. Multi-Line Coordination (Post-MVP)**
- **Shared Resources:** Workers cross-trained across lines
- **Material Sharing:** Central buffer feeds multiple lines
- **Dynamic Rebalancing:** MES shifts loads based on real-time demand

**Functional Example:**

```
Scenario: Two Concurrent Contracts

Contract A: 300 engines v1/week (Mature product, low margin)
Contract B: 200 engines v2/week (New product, high margin)

Current Setup:
Line 1: Lathe→CNC→Assembly (capacity: 250/week, currently idle)
Line 2: Lathe→CNC→Assembly→QC (capacity: 180/week, producing v2)

Analysis:
- Total demand: 500/week
- Total capacity: 430/week → SHORT 70 units/week

Options:
A. Expand Line 1 (add CNC) → +100/week capacity, costs $25k + $3.5k/mo worker
B. Optimize Line 2 MES → +10% = 18 units/week gain (still short 52/week)
C. Decline Contract A (reputation hit)
D. Extend Contract B deadline (negotiate -5% revenue)

Optimal Strategy (depends on cash):
- Strong cash position: Option A (invest in growth)
- Weak cash: Option B + D (optimize existing, negotiate time)
- Strategic: Option A but prioritize high-margin Contract B first, accept late penalty on Contract A (-$5k) if needed to avoid losing both
```

---

### Pillar 8: Research & Technology Tree

**Description:**  
Unlock machines, automation features, MES capabilities, and advanced systems through a tiered tech tree funded by XP and Challenge Points.

**Tech Tree Structure (5 Tiers, 50+ Nodes):**

**Tier 0: Tutorial (Pre-unlocked)**
- Basic Lathe
- Basic CNC
- Manual Conveyor
- Basic Buffer
- Simple Assembly Station
- GUI Parameter Sliders
- Single-Shift Operation

**Tier 1: Early Optimization (Levels 1-5, ~3 hours playtime)**
- Worker Skill Training (+10% efficiency)
- Multi-Shift Support (2 shifts/day)
- MES Presets Library (10 templates)
- Basic Maintenance Scheduling
- Small Buffer Upgrade (50 → 100 capacity)
- Excel Export (production reports)

**Tier 2: Automation Basics (Levels 6-10, ~8 hours playtime)**
- Block-Based MES Editor (IF-THEN logic)
- Advanced CNC (faster, more precise)
- Atlas Nutrunners (precision torque)
- QC Station Automation
- Multi-Version Production Support
- Contract Negotiation (unlock better terms)

**Tier 3: Multi-Line Operations (Levels 11-15, ~20 hours playtime)**
- AGV (Automated Guided Vehicle) System
- Multi-Line Planning Dashboard
- Worker Cross-Training
- Advanced R&D Lab (co-development contracts)
- Predictive Maintenance Alerts
- Custom MES Templates (save/share)

**Tier 4: Advanced Automation (Levels 16-20, ~40 hours playtime)**
- Lua MES Scripting
- MES Simulation Mode (test before deploy)
- Robotic Assembly Arms
- Digital Twin Preview (simulate production runs)
- Bulk Material Handling
- Premium Supplier Contracts

**Tier 5: Global Operations (Levels 21-25, ~60+ hours playtime, post-MVP)**
- Multi-Factory Management
- Global Supply Chain Optimization
- AI-Assisted MES (auto-generates scripts)
- Advanced Analytics Dashboard
- Workshop Integration (share factories)
- Prestige System (New Game+)

**Unlock Costs:**

| Tier | XP Cost (avg) | Challenge Points | Example Node |
|------|---------------|------------------|--------------|
| 0 | 0 | 0 | Tutorial content |
| 1 | 500-1,000 | 0 | Worker training |
| 2 | 1,500-3,000 | 50-100 | Block MES editor |
| 3 | 5,000-10,000 | 200-400 | AGV system |
| 4 | 15,000-25,000 | 500-800 | Lua scripting |
| 5 | 50,000+ | 1,000+ | Multi-factory |

**Strategic Tech Paths (Player Specialization):**

**Path A: "The Optimizer"**
- Prioritize: MES editor → Advanced machines → Simulation tools
- Playstyle: Perfect efficiency on fewer lines
- Endgame: 99.9% OEE, zero scrap, highest margins

**Path B: "The Expander"**
- Prioritize: Multi-shift → Worker training → AGVs → Multi-line
- Playstyle: Scale volume, many concurrent contracts
- Endgame: Massive throughput, moderate efficiency

**Path C: "The Innovator"**
- Prioritize: R&D lab → Co-development → In-house products
- Playstyle: Build IP portfolio, diverse products
- Endgame: Licensing revenue, premium customers

**Path D: "The Balanced Tycoon"**
- Prioritize: Even distribution across all trees
- Playstyle: Jack-of-all-trades, adaptable
- Endgame: Resilient to events, steady growth

---

### Pillar 9: Economy & Finance

**Description:**  
Manage cash flow, track expenses, maximize revenue, and make strategic financial decisions that affect company growth.

**Revenue Streams:**

1. **Contract Payments**
   - Base revenue: $20k - $500k per contract
   - Bonuses: +10-30% for early/perfect delivery
   - Penalties: -5-25% for late/defective delivery

2. **Ongoing Sales (In-House Products)**
   - Royalty/licensing: $5k-$20k per month per customer
   - Volume-based: More customers = more revenue
   - Passive income stream

3. **Efficiency Bonuses**
   - <2% scrap rate: +5% contract bonus
   - >95% on-time delivery: +10% reputation gain
   - Challenge completion: $5k-$25k one-time rewards

**Expense Categories:**

1. **Fixed Costs (Monthly)**
   - Facility Rent: $5,000/month (base factory)
   - Utilities: $2 per kWh × total machine power
   - Insurance: $1,000/month

2. **Variable Costs (Per Unit)**
   - Raw Materials: $50-$120 per engine (depends on specs)
   - Labor: $2,500-$6,000 per worker per month
   - Maintenance: $500-$1,000 per machine per 1000 cycles
   - Scrap: 100% material cost + cycle time waste

3. **Capital Expenditures**
   - Machines: $8k - $40k (one-time)
   - Facility Expansion: $50k per 20x20 grid expansion
   - R&D Projects: $10k - $150k (one-time investment)

**Cash Flow Management:**

**Healthy Example:**
```
Month 3 Summary:
Revenue:
  Contract A (delivered): $85,000
  Contract B (milestone): $40,000
  In-house product royalty: $12,000
  Total: $137,000

Expenses:
  Worker salaries (5 workers): -$17,500
  Materials (800 units × $60): -$48,000
  Maintenance: -$3,000
  Utilities: -$4,500
  Fixed costs: -$6,000
  Total: -$79,000

Net Profit: +$58,000
Cash Balance: $183,000 (healthy)
```

**Crisis Example:**
```
Month 8 Summary:
Revenue:
  Contract C (late penalty): $95,000 → $76,000 (-20%)
  No other deliveries this month
  Total: $76,000

Expenses:
  Worker salaries (8 workers): -$32,000
  Materials (purchased in advance): -$65,000
  Emergency machine repair: -$18,000
  Fixed costs: -$6,000
  Total: -$121,000

Net Loss: -$45,000
Cash Balance: $22,000 → DANGER ZONE

Player Response:
A. Take credit line loan: $50k at 5%/month
B. Sell idle machines: Liquidate $35k worth
C. Lay off 2 workers: Save $6k/month (but lose capacity)
D. Renegotiate contract deadline: -5% more revenue but avoid further penalties
```

**Financial Milestones:**

| Milestone | Cash Threshold | Unlock/Achievement |
|-----------|----------------|-------------------|
| Break Even | $0 (positive cash flow) | "Profitable" achievement |
| Small Business | $100,000 | Unlock credit line |
| Medium Enterprise | $500,000 | Unlock facility expansion |
| Large Corporation | $2,000,000 | Unlock multi-factory (Tier 5) |

---

### Pillar 10: Challenge & Event System

**Description:**  
Dynamic events and structured challenges test player skill, provide variety, and reward mastery.

**Event Types:**

**1. Random Events (1-3 per month)**

**A. Machine Breakdowns**
- Trigger: Random 2% chance per machine per week
- Impact: Machine offline for 2-8 hours (game time)
- Player Response:
  - Pay emergency repair: $5k-$15k, 2h downtime
  - Schedule maintenance: $2k-$5k, 6h downtime
  - Reroute production via MES (if AGVs unlocked)

**B. Supply Chain Disruptions**
- Trigger: Random 5% chance per month
- Impact: Delayed material delivery (2-5 days)
- Severity Tiers:
  - Minor: +1 day delivery, no cost impact
  - Moderate: +3 days, must use premium supplier (+15% cost)
  - Major: +5 days, may miss contract deadline
- Player Response:
  - Accept delay (may trigger contract penalty)
  - Pay rush order: 2× material cost, next-day delivery
  - Use existing stock if sufficient

**C. Worker Illness**
- Trigger: 3% chance per worker per month
- Impact: Worker unavailable for 3-7 days
- Player Response:
  - Reassign tasks (may reduce efficiency)
  - Hire temp worker: $5k, skill 30-40 (lower than permanent)
  - Work overtime (increases fatigue on remaining workers)

**D. Quality Control Spike**
- Trigger: Random when scrap rate >5% for 3 consecutive days
- Impact: Customer requests audit, may increase QC frequency
- Player Response:
  - Accept audit (costs $10k, may find process improvements)
  - Improve MES parameters immediately
  - Increase QC sampling (costs time, ensures quality)

**E. Market Opportunities**
- Trigger: Random 10% chance per month
- Impact: Limited-time contract offer (2× normal margin but tight deadline)
- Player Response:
  - Accept (high risk, high reward)
  - Decline (safe, no penalty)
  - Negotiate (reduce margin to 1.5× but extend deadline)

**2. Structured Challenges (5 per tier, 25 total)**

**Tier 1 Challenges (Levels 1-5):**
1. **"First Contract"**
   - Goal: Complete tutorial contract with <5% scrap
   - Reward: $5k bonus + 500 XP
2. **"Efficiency Expert"**
   - Goal: Achieve 90% OEE (Overall Equipment Effectiveness) for 1 week
   - Reward: MES preset library unlock + 50 CP
3. **"Budget Manager"**
   - Goal: Turn profit for 2 consecutive months
   - Reward: $10k bonus + credit line unlock
4. **"Quality Focused"**
   - Goal: Deliver contract with 0% scrap (all parts pass QC)
   - Reward: Reputation +10 + 100 CP
5. **"Rapid Production"**
   - Goal: Produce 100 units in 3 days
   - Reward: Worker training unlock + 75 CP

**Tier 2 Challenges (Levels 6-10):**
1. **"Multi-Tasker"**
   - Goal: Complete 2 contracts simultaneously
   - Reward: Multi-line planning tool + 150 CP
2. **"MES Master"**
   - Goal: Write 3 working block-based MES rules
   - Reward: Advanced MES templates + 200 CP
3. **"R&D Pioneer"**
   - Goal: Successfully complete first R&D project
   - Reward: $25k + co-development contract access
4. **"Perfect Week"**
   - Goal: 7 days with 0 machine downtime, 0 scrap, all contracts on schedule
   - Reward: $15k bonus + 250 CP
5. **"Expansion Ready"**
   - Goal: Reach $200k cash reserve
   - Reward: Facility expansion unlock + 100 CP

**Tier 3-5 Challenges:** (Similar structure, increasing difficulty and rewards)

---

## 1.4 Core Gameplay Loop (Detailed Functional Flow)

**Primary Loop (Per Contract Cycle):**

```
┌─────────────────────────────────────────────────────────┐
│ 1. ACQUIRE CONTRACT                                     │
│    - Review offers (OEM / Co-Dev / In-House)           │
│    - Negotiate terms (deadline, payment, penalties)     │
│    - Accept or decline                                  │
└────────────────┬────────────────────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────────────────────┐
│ 2. PLAN PRODUCTION                                      │
│    - Assign product to line(s)                          │
│    - Schedule shifts and workers                        │
│    - Order materials (lead time consideration)          │
│    - Set MES parameters (presets or custom)             │
└────────────────┬────────────────────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────────────────────┐
│ 3. EXECUTE PRODUCTION                                   │
│    - Start line (activate machines)                     │
│    - Monitor real-time: throughput, scrap, bottlenecks  │
│    - MES rules apply automatically                      │
│    - Workers execute tasks                              │
└────────────────┬────────────────────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────────────────────┐
│ 4. RESPOND TO ISSUES                                    │
│    - Machine breakdown → repair or reroute              │
│    - Bottleneck detected → add capacity or optimize     │
│    - QC failure spike → adjust MES parameters           │
│    - Material delay → expedite or reschedule            │
└────────────────┬────────────────────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────────────────────┐
│ 5. QUALITY CONTROL                                      │
│    - QC station samples parts (%)                       │
│    - Defects detected → rework or scrap                 │
│    - Acceptance rate tracked against contract spec      │
└────────────────┬────────────────────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────────────────────┐
│ 6. DELIVER & COLLECT PAYMENT                            │
│    - Units shipped to customer                          │
│    - Revenue calculated (base + bonuses - penalties)    │
│    - Reputation updated                                 │
│    - XP and Challenge Points awarded                    │
└────────────────┬────────────────────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────────────────────┐
│ 7. OPTIMIZE & EXPAND                                    │
│    - Review analytics (scrap %, OEE, bottlenecks)       │
│    - Invest profits: new machines, workers, R&D         │
│    - Unlock tech tree nodes                             │
│    - Prepare for next contract                          │
└────────────────┬────────────────────────────────────────┘
                 │
                 └──────────────┐
                                │
                 ┌──────────────┘
                 ▼
         [LOOP REPEATS]
```

**Secondary Loops:**

**R&D Loop (Parallel to Production):**
```
Allocate Engineers → R&D Progress → Success/Failure → 
New Product/Part → Add to PLM → Available for Contracts
```

**Worker Development Loop:**
```
Assign to Machine → Gain Experience → Level Up → 
Unlock Certification → Higher Efficiency → Assign to Advanced Tasks
```

**Tech Progression Loop:**
```
Complete Contracts/Challenges → Earn XP/CP → 
Unlock Tech Nodes → New Capabilities → 
Accept Harder Contracts → Earn More XP/CP
```

---

## 1.5 Player Progression

**Phase 1: Foundation (Levels 1-5, Hours 0-5)**

**Starting State:**
- Cash: $50,000
- Machines: 1× Lathe, 1× CNC (pre-placed)
- Workers: 2× Level 1 workers (skill 45)
- Tech: Tier 0 fully unlocked

**Learning Goals:**
- Understand grid placement
- Assign workers to machines
- Complete tutorial contract
- Use MES presets (no scripting yet)

**End State:**
- Cash: ~$120,000 (if efficient)
- Machines: +1 Assembly Station
- Workers: +1 worker (hired)
- Tech: Tier 1 partially unlocked
- Reputation: 25-35

**Key Milestone:** First profitable contract delivered

---

**Phase 2: Growth (Levels 6-10, Hours 5-15)**

**Focus:**
- Multi-shift operations
- First multi-contract scenario (2 concurrent)
- Introduction to PLM (ECO event)
- Basic block-based MES rules

**Challenges:**
- Manage fatigue across shifts
- Handle first supply chain disruption
- Complete first ECO successfully
- Balance 2 contracts with 1 production line (tight capacity)

**End State:**
- Cash: ~$300,000
- Machines: 2 full lines (Lathe→CNC→Assembly each)
- Workers: 5-6 workers (mix of skill levels)
- Tech: Tier 2 unlocking
- Reputation: 50-60

**Key Milestone:** First co-development contract or successful multi-contract month

---

**Phase 3: Optimization (Levels 11-15, Hours 15-35)**

**Focus:**
- Multi-line planning and coordination
- Advanced MES scripting (block-based mastery)
- AGV unlock and implementation
- First in-house R&D project

**Challenges:**
- Manage 3-4 concurrent contracts
- Handle multi-version production (v1, v2 on same line)
- Optimize for <2% scrap consistently
- Complete advanced challenges (Perfect Week, etc.)

**End State:**
- Cash: ~$750,000
- Machines: 3-4 production lines + AGVs
- Workers: 10-12 workers (some specialists)
- Tech: Tier 3 mostly unlocked
- Reputation: 70-80

**Key Milestone:** First in-house product launched, passive royalty income

---

**Phase 4: Mastery (Levels 16-20, Hours 35-60)**

**Focus:**
- Lua MES scripting (optional but powerful)
- Digital twin simulation
- Complex multi-line optimization
- Predictive maintenance implementation

**Challenges:**
- Manage 6+ concurrent contracts
- Handle major crisis events (multiple simultaneous)
- Achieve 99%+ OEE for extended periods
- Complete all Tier 3-4 challenges

**End State:**
- Cash: ~$1,500,000
- Machines: 5-7 production lines, fully automated
- Workers: 15-20 workers (many certified specialists)
- Tech: Tier 4 mostly unlocked
- Reputation: 85-95

**Key Milestone:** Unlock multi-factory capability (Tier 5 preview)

---

**Phase 5: Endgame (Levels 21-25, Hours 60+, Post-MVP)**

**Focus:**
- Global operations (multiple factories)
- AI-assisted optimization
- Community content (Workshop)
- Prestige system (New Game+ optional)

**Challenges:**
- Coordinate 3 factories across different regions
- Maximize global supply chain efficiency
- Complete ultimate challenges (community leaderboards)
- Perfect automation (AI runs factory autonomously)

**End State:**
- Cash: $5,000,000+
- Reputation: 95-100
- All tech unlocked
- All achievements completed

**Key Milestone:** Mastery ending or Prestige reset for bonuses

---

## 1.6 Playstyles Supported

The game explicitly supports 4 distinct playstyles without forcing any particular path:

### Style 1: Casual Tycoon
**Focus:** Revenue growth, factory expansion  
**Engagement:** GUI tools, presets, minimal complexity  
**Avoids:** MES scripting, deep planning, multi-line optimization  
**Rewards:** Achieves ~70-85% theoretical max efficiency, still profitable and fun  
**Example Session:** Accept OEM contract → use preset MES → assign workers via GUI → watch factory run → collect payment → buy new machine

### Style 2: Strategic Planner
**Focus:** Optimization, efficiency maximization  
**Engagement:** Planning tools, analytics, worker/shift management  
**Uses:** Some block-based MES, capacity analysis, challenge completion  
**Rewards:** Achieves 85-95% efficiency, high profit margins, challenge bonuses  
**Example Session:** Analyze bottleneck heatmap → reassign skilled worker to bottleneck → create MES rule for v2 parts → test in simulation → deploy → efficiency +12%

### Style 3: Engineer / Automation Expert
**Focus:** Perfect automation, MES mastery  
**Engagement:** Lua scripting, complex logic, multi-system integration  
**Uses:** Full MES capabilities, digital twin, predictive systems  
**Rewards:** Achieves 95-100%+ efficiency, highest Challenge Points, community recognition  
**Example Session:** Write Lua script to dynamically balance 3 lines → integrate predictive maintenance → test edge cases → deploy → share script in Workshop → receive community feedback

### Style 4: Business Strategist
**Focus:** R&D portfolio, customer relationships, long-term planning  
**Engagement:** Contract negotiation, co-development, IP licensing  
**Uses:** R&D tools, market analysis, strategic investment  
**Rewards:** Diverse income streams, premium contracts, reputation-based unlocks  
**Example Session:** Negotiate exclusivity deal (+15% revenue) → allocate 4 engineers to in-house engine → launch product → license to 3 customers → receive $45k/month passive income

**Key Design Principle:** All 4 styles are equally valid paths to success. No style is "wrong" or "suboptimal" - they're different ways to enjoy the game.

---

## 1.7 Example Functional Use Cases

### Use Case 1: MES Scripting Impact (Casual vs Expert)

**Scenario:** Produce 500 engines/week for OEM contract

**Casual Player Approach:**
- Uses preset: "Standard Production - Medium Speed"
- Assigns workers randomly to machines
- Achieves: 480 units/week, 4% scrap rate
- Revenue: $85,000 (base) - $4,250 (scrap penalty) = $80,750
- Time investment: 30 minutes setup, minimal monitoring

**Strategic Player Approach:**
- Uses block-based MES rule:
  ```
  IF Part.version = 2 THEN
    Machine.torque = 95Nm
    QC.sampleRate = 10%
  END
  ```
- Assigns high-skill worker to bottleneck CNC
- Achieves: 510 units/week, 2.5% scrap rate
- Revenue: $85,000 (base) + $4,250 (efficiency bonus) = $89,250
- Time investment: 2 hours initial setup, 15 min/day monitoring

**Expert Player Approach:**
- Writes Lua MES script:
  ```lua
  function onPartArrive(part)
    if part.version >= 2 then
      if machine.tool_wear > 0.7 then
        scheduleMaintenance()
        adjustSpeed(0.95)  -- Slight slowdown prevents scrap
      end
      applyTorqueProfile("precision_v2")
    end
  end
  ```
- Uses digital twin to simulate week before production
- Achieves: 530 units/week, 1.8% scrap rate
- Revenue: $85,000 (base) + $8,500 (perfect delivery bonus) = $93,500
- Time investment: 6 hours initial development, 5 min/day monitoring (automated)

**Result:** All 3 players complete contract successfully, but rewards scale with mastery (+16% revenue for expert vs casual). Casual player still profitable and had fun - this is critical.

---

### Use Case 2: ECO Event Handling

**Event:** Customer requests Crankshaft v1 → v2 upgrade

**Changes Required:**
- Torque: 85Nm ± 2Nm → 95Nm ± 1Nm (tighter tolerance)
- Material: Standard Steel → High-Carbon Steel (+$15/unit)
- QC Sampling: 5% → 10% (more frequent inspection)

**Player Options:**

**Option A: Accept (Auto-Implementation)**
- Game auto-updates MES parameters
- Auto-schedules worker training (4 hours total)
- Player confirms, production continues
- Impact: 2-hour downtime for training, +$15/unit cost, scrap stable at 3%
- Outcome: Contract continues smoothly, reputation +5

**Option B: Decline**
- Contract terminated immediately
- Reputation -20 (severe penalty)
- Lose $150k remaining revenue
- Customer relationship damaged (may not offer future contracts)

**Option C: Negotiate Extension**
- Request 2-week deadline extension to prepare
- Customer accepts but reduces base revenue by 5%
- Player uses extra time to optimize MES, train workers thoroughly
- Impact: Revenue -$7,500, but player achieves 1.5% scrap (vs 3% if rushed)
- Outcome: Lower immediate revenue but better long-term efficiency

**Option D: Manual MES Update (Expert)**
- Player writes custom MES rule to handle both v1 (old orders) and v2 (new orders) simultaneously
- Uses conditional logic: `IF Part.version == 2 THEN apply_v2_profile()`
- Impact: 0 downtime, can fulfill old v1 orders while ramping v2
- Outcome: Maximum flexibility, reputation +10 for smooth transition

**Strategic Analysis:** Option D is optimal but requires skill. Option C is safe for new players. Option A is acceptable default. Option B should almost never be chosen (demonstrates consequences of poor planning).

---

### Use Case 3: Bottleneck Crisis Management

**Situation:**
- Contract requires 600 engines/week
- Current line capacity: 520 engines/week (bottleneck: CNC)
- Deadline: 4 weeks
- Current production: Week 1 complete = 520 units (SHORT 80 units)

**Analysis:**
- Projected shortage: 80 × 4 weeks = 320 units short
- Penalty: -$5k per 50 units short = -$32k penalty
- Risk: Contract failure, reputation loss

**Player Options:**

**A. Emergency Machine Purchase**
- Buy 2nd CNC: $25,000
- Hire worker: $5,000 + $3,500/month
- Installation time: 1 day (minimal downtime)
- New capacity: 520 + 180 = 700 engines/week
- Impact: -$30k immediate, +$3.5k/month ongoing, SURPLUS capacity
- Outcome: Contract fulfilled early, +$8k bonus, unlocks future high-volume contracts

**B. MES Optimization**
- Spend 4 hours optimizing CNC parameters
- Reduce cycle time 12% (free, requires skill)
- New capacity: 520 + 62 = 582 engines/week
- Impact: Still short 18 units/week = 72 total
- Outcome: Reduces penalty to -$7.2k, acceptable if cash-tight

**C. Negotiate Contract Reduction**
- Request volume reduction: 600 → 550 units/week
- Customer accepts but reduces revenue by 10%
- Impact: -$15k revenue, no penalty
- Outcome: Safe option, preserves reputation, lower profit

**D. Overtime + Material Expediting**
- Run 3rd shift (overtime pay: 1.5× labor cost)
- Expedite material delivery (+20% cost)
- Workers gain fatigue rapidly (efficiency drops over time)
- Impact: +$18k costs, +80 units capacity initially, but fatigue causes slowdown Week 3-4
- Outcome: Risky - may still miss deadline if fatigue not managed

**E. Hybrid: B + Renegotiate Deadline**
- Optimize MES (+62 units/week)
- Request 1-week extension (-5% revenue)
- Impact: -$7.5k revenue, achieves 582×5 weeks = 2,910 units (exceeds 2,400 needed)
- Outcome: Low cost, low risk, meets contract, modest profit

**Optimal Strategy (depends on player context):**
- **Strong cash position:** Option A (invest in future capacity)
- **Limited cash:** Option E (smart optimization + negotiation)
- **Intermediate:** Option B if confident in MES skills
- **Risk-averse:** Option C (safe, preserves relationships)

**What This Teaches:** Multiple valid solutions. Game rewards planning (Option A), skill (Option B), and negotiation (Option C/E). Panic responses (Option D) often backfire.

---

## 1.8 Success Metrics (How We Know the Game Works)

**Metric 1: Completion Rate**
- **Target:** 60% of players complete tutorial contract
- **Measure:** Tutorial completion achievement unlock rate

**Metric 2: Retention**
- **Target:** 40% of players return for Session 2 (next day)
- **Target:** 20% of players still playing after 10 hours

**Metric 3: Feature Adoption**
- **Target:** 30% of players use block-based MES editor
- **Target:** 5% of players write Lua scripts (post-MVP)
- **Measure:** Telemetry tracking MES panel opens and rule creations

**Metric 4: Playstyle Distribution**
- **Target:** 40% Casual, 35% Strategic, 20% Engineer, 5% Business
- **Measure:** Cluster analysis of player behaviors (MES usage, contract types, R&D investment)

**Metric 5: Difficulty Balance**
- **Target:** <10% of players quit due to frustration (vs boredom or completion)
- **Measure:** Exit surveys + analytics (where do players stop?)

**Metric 6: Monetization (Early Access)**
- **Target:** $14.99 price point, 5,000 units sold first month
- **Measure:** Steam sales data

**Metric 7: Community Engagement (Post-MVP)**
- **Target:** 100+ Workshop items uploaded in first 3 months
- **Target:** 50+ active forum participants

---

This concludes **Section 1: Executive Summary & Core Gameplay Overview**. The remaining sections (2-18) follow the same level of detail, incorporating all missing elements, technical specifications, and design decisions tailored to your solo development approach with MVP focus.

---

# 2. FACTORY SYSTEMS (Machines, Workers, Conveyors)

## 2.1 Factory Overview

The factory is the **core interactive environment** where all production occurs. Players interact with production systems through a **top-down 2D grid-based canvas**, placing machines, assigning workers, managing material flow, and observing real-time production metrics.

### Grid Layout Specifications

**Grid Structure:**
- **Cell Size:** 64x64 pixels (represents 1m² in game world)
- **Default Factory Size:** 30×30 cells (900m², expandable to 100×100)
- **Visual Layers (Z-order, bottom to top):**
  1. Floor grid (static background)
  2. Conveyors and material paths
  3. Machines and buffers
  4. Workers (animated sprites)
  5. Parts/WIP (moving objects)
  6. Visual effects (sparks, steam, alerts)
  7. UI overlays (heatmaps, labels)

**Zones (Color-Coded):**
- **Receiving (Blue):** Raw material storage, supplier deliveries
- **Machining (Gray):** CNC, Lathe, cutting operations
- **Assembly (Green):** Bolt tightening, component assembly
- **QC (Yellow):** Quality inspection stations
- **Storage (Orange):** WIP buffers, finished goods inventory
- **Dispatch (Purple):** Shipping, customer deliveries
- **R&D (Cyan):** Engineering workspace (Phase 4+)

**Functional Principle:**  
Each machine occupies 1-6 cells depending on type, has defined input/output connection points, and requires worker assignment for operation. Material flows follow conveyor paths, with buffer queues preventing bottlenecks.

---

## 2.2 Machines (Manufacturing Equipment)

### 2.2.1 Machine Classification

Machines are categorized by **ISA-95 Level** to reflect real-world manufacturing hierarchy:

**Level 0 (Process):** Not directly represented (abstracted as machine internal logic)

**Level 1 (Control):**  
Each machine has an internal **PLC (Programmable Logic Controller)** that:
- Executes NC (Numerical Control) programs for CNC/Lathe
- Manages tool paths, speeds, feeds
- Monitors sensors (temperature, vibration, torque feedback)
- Reports status to Level 2

**Level 2 (Supervision):**  
**SCADA/HMI Interface** (visualized in machine detail panel):
- Real-time machine status display
- Alarm notifications
- Manual operator controls (emergency stop, parameter override)

**Level 3 (MES):**  
MES system (Section 3) orchestrates all machines via **OPC-UA protocol**:
- Sends production orders (work orders)
- Receives telemetry (cycle times, part counts, errors)
- Adjusts parameters dynamically (torque profiles, speeds)
- Tracks part genealogy (serial numbers, batch IDs)

**Level 4 (ERP):**  
ERP system receives aggregated data (Section 4B):
- Material consumption (stock levels updated)
- Production outputs (finished goods inventory)
- Cost tracking (machine hours, scrap waste)

---

### 2.2.2 Machine Types (Detailed Specifications)

### A. CNC Mill
**Function:** Precision cutting and shaping of engine blocks, cylinder heads  
**Real-World Analog:** Haas VF-3, DMG Mori NVX 5100  
**Size:** 3×3 cells  
**Cost:** $35,000 (purchase), $1,200/1000 cycles (maintenance)  
**Power:** 8 kW  

**Capabilities:**
- Materials: Steel, aluminum, cast iron
- Precision: ±0.01mm
- Max part size: 600×400×300mm
- Tool magazine: 20 tools (drill bits, end mills, face mills)

**NC Program Example (abstracted in-game):**
```
G0 X10 Y10 Z5    // Rapid position
G1 Z-2 F100      // Feed to depth
G1 X50 F200      // Cut along X axis
M5               // Spindle stop
```

**Parameters (Player-Adjustable):**
- **Spindle Speed:** 500-8000 RPM (affects cycle time & tool wear)
- **Feed Rate:** 50-500 mm/min (affects surface finish & cycle time)
- **Cut Depth:** 0.5-5mm per pass (affects quality & tool stress)
- **Coolant Flow:** On/Off (reduces heat, extends tool life)

**MES Integration:**
- Receives work order: "Mill engine block v2, material: aluminum"
- Loads NC program from MES database
- Executes program, reports progress via OPC-UA
- Sends completion signal + actual cycle time to MES
- MES updates ERP inventory: -1 aluminum billet, +1 engine block (roughed)

**Failure Modes:**
- Tool breakage (5% chance if feed rate too high)
- Thermal deformation (3% chance if coolant off + high speed)
- Crash (1% chance if worker skill <50 during setup)

**Functional Example:**
- **Setup:** Player assigns skilled worker (lvl 65), loads "Engine Block v2" program via MES
- **Execution:** CNC runs automatically, 12-minute cycle time
- **Result:** 5 parts/hour, 2% scrap rate (optimal parameters)
- **Sub-Optimal:** Unskilled worker (lvl 30) + high feed rate = 8% scrap, frequent tool changes

---

### B. CNC Lathe
**Function:** Cylindrical parts (crankshafts, pistons, shafts)  
**Real-World Analog:** Okuma LB3000, Mazak QuickTurn 250  
**Size:** 2×4 cells  
**Cost:** $28,000, $900/1000 cycles  
**Power:** 6 kW  

**Capabilities:**
- Materials: Forged steel, aluminum
- Max diameter: 300mm, length: 600mm
- Precision: ±0.02mm
- Live tooling (optional, Tier 3 unlock): milling operations on lathe

**Parameters:**
- **Spindle Speed:** 100-3000 RPM
- **Feed Rate:** 0.05-0.5 mm/rev
- **Cut Depth:** 0.2-3mm
- **Turning vs. Facing Mode:** Affects cycle time distribution

**MES Integration:**
- Work order includes part drawing (diameter, length, tolerances)
- MES generates or retrieves NC program
- Lathe executes, OPC-UA streams real-time position data
- Completed part tagged with serial number (traceability)

---

### C. Assembly Station (Manual + Powered Tools)
**Function:** Bolt assembly, component fitting  
**Real-World Analog:** Ergonomic workbench + handheld power tools  
**Size:** 2×2 cells  
**Cost:** $12,000, $400/1000 cycles  
**Power:** 1.5 kW  

**Operations:**
- Bolt tightening (torque-critical)
- Snap-fit assembly
- Gasket application
- Wiring harness connection

**Parameters:**
- **Torque Setting:** 5-150 Nm (part-specific)
- **Sequence Order:** Critical for structural integrity
- **Tool Selection:** Manual wrench, powered driver, Atlas Nutrunner

**Worker Dependency:**  
Assembly quality highly dependent on worker skill:
- Skill <40: 15% error rate (wrong torque, sequence mistakes)
- Skill 40-70: 5% error rate
- Skill >70: <2% error rate

**MES Integration:**
- Work instruction displayed on HMI screen at station
- Step-by-step sequence with photos/diagrams
- Torque wrench reports actual torque via Bluetooth to MES
- MES verifies each step completion before allowing next

---

### D. Atlas Nutrunner (Precision Torque System)
**Function:** Critical bolt tightening with exact torque + angle control  
**Real-World Analog:** Atlas Copco PowerFocus 6000, Bosch Rexroth Nexo  
**Size:** 1×1 cell (handheld tool on articulated arm)  
**Cost:** $18,000, $300/1000 cycles  
**Power:** 0.8 kW  

**Why Atlas Nutrunners Matter:**  
In engine assembly, critical fasteners (cylinder head bolts, connecting rod bolts) require **precise torque AND angle** to ensure:
- No undertightening (gasket leaks, joint failure)
- No overtightening (thread stripping, bolt fracture)

**Torque Strategy Types:**
1. **Torque Control:** Tighten to X Nm (±2%)
2. **Torque + Angle:** Tighten to X Nm, then rotate Y degrees
3. **Yield Point:** Tighten until bolt reaches elastic limit (advanced)

**Parameters (MES-Controlled):**
- **Target Torque:** Part-specific (e.g., M12 bolt = 85 Nm)
- **Torque Tolerance:** ±1 Nm (tight) to ±5 Nm (loose)
- **Angle:** 0-180° (for torque-angle strategy)
- **Tightening Speed:** 10-50 RPM (affects accuracy)
- **Retightening:** Optional 2nd pass for critical joints

**MES Integration (Advanced Example):**
```
MES Work Order: "Cylinder Head Assembly - Engine v2"
Part: M12 x 1.75 bolt, Grade 10.9
Sequence:
  1. Bolt 1 (front-left): 25 Nm
  2. Bolt 2 (front-right): 25 Nm
  3. Bolt 3 (rear-right): 25 Nm
  4. Bolt 4 (rear-left): 25 Nm
  5. REPEAT: All bolts → 50 Nm
  6. REPEAT: All bolts → 85 Nm + 90° angle
  
MES Validation:
- Each bolt tightening sends actual torque + angle to MES
- If any bolt outside tolerance → STOP, alert operator
- If all pass → Mark assembly as "Torque Verified", proceed to QC
```

**Functional Example (Multi-Version Production):**
- Engine v1 uses 85 Nm bolts
- Engine v2 uses 95 Nm bolts (upgraded spec)
- MES rule (player-created):
  ```
  IF Part.version == 1 THEN
    Nutrunner.setTorque(85, tolerance=2)
  ELSE IF Part.version == 2 THEN
    Nutrunner.setTorque(95, tolerance=1)
  END
  ```
- Atlas Nutrunner receives command via OPC-UA before each bolt
- Worker doesn't need to remember - tool auto-configures

**Quality Impact:**
- Proper torque: 0.5% defect rate
- Manual torque (no Nutrunner): 8% defect rate
- Wrong torque setting: 25% defect rate (catastrophic)

---

### E. QC Inspection Station
**Function:** Dimensional inspection, functional testing  
**Real-World Analog:** CMM (Coordinate Measuring Machine), Vision system  
**Size:** 2×2 cells  
**Cost:** $22,000, $200/1000 inspections  
**Power:** 1 kW  

**Inspection Types:**
1. **Dimensional:** Measure critical dimensions (dial indicators, CMM)
2. **Visual:** Surface defects, paint quality (camera + AI)
3. **Functional:** Leak test, pressure test
4. **Torque Audit:** Re-check bolt torque on sample parts

**Sampling Strategy (MES-Configured):**
- **100% Inspection:** All parts (slow, expensive, high-confidence)
- **10% Sampling:** Every 10th part (standard)
- **Statistical (SPC):** Measure 5 parts/hour, track trend
- **First Article:** Inspect first unit of new batch thoroughly

**Parameters:**
- **Sample Rate:** 1-100%
- **Tolerance:** Part-specific (e.g., ±0.05mm for critical features)
- **Fail Action:** Scrap / Rework / Hold for review

**MES Integration:**
- QC station receives inspection plan from MES
- Results logged per part serial number
- If out-of-spec detected → MES alerts player, may auto-adjust upstream machine parameters
- Trend analysis: if 3 consecutive parts near upper limit → MES flags "process drift"

**Functional Example (Predictive QC):**
```
MES detects pattern:
- Parts 101-105: all within spec, but trending toward upper limit
- Part 106: FAILS (exceeds +0.06mm tolerance)

MES Response (if player enabled "Auto-Adjust"):
- Adjust CNC feed rate -5% (reduces thermal expansion)
- Increase coolant flow +10%
- Alert player: "QC drift corrected on Line 2"
- Next 5 parts: back in spec, scrap avoided
```

---

### F. Conveyor System
**Function:** Material transport between machines  
**Types:**
- **Belt Conveyor:** Continuous flow, 0.5 m/s
- **Roller Conveyor:** Heavy parts, 0.3 m/s
- **Overhead Conveyor:** Space-saving, 0.4 m/s

**Cost:** $500 per cell (1m segment)  
**Power:** 0.1 kW per 5 cells  

**Parameters:**
- **Speed:** 0.2-1.0 m/s (affects WIP time)
- **Direction:** One-way or bidirectional (advanced)
- **Merge/Split Points:** Routing logic

**MES Integration:**
- Sensors detect part presence (photoelectric sensors)
- RFID tags on parts → MES tracks part location in real-time
- Automated routing: "IF part.destination == Assembly THEN route_left ELSE route_right"

---

### G. Buffer / Storage Queue
**Function:** Temporary part storage between operations  
**Types:**
- **FIFO Buffer:** First-in-first-out (standard)
- **LIFO Buffer:** Last-in-first-out (rework station)
- **Sorted Buffer:** Parts organized by priority (advanced)

**Cost:** $2,500 (50-part capacity)  
**Size:** 1×2 cells  

**Mechanics:**
- **Input Rate vs. Output Rate:** If input > output → buffer fills → backlog
- **Buffer Full:** Upstream machine must STOP (prevents part loss)
- **Buffer Empty:** Downstream machine STARVED (idle time)

**Visual Indicators:**
- <25% full: Green
- 25-75%: Yellow (warning - balance line)
- >75%: Red (critical - bottleneck ahead)

**MES Integration:**
- MES monitors buffer occupancy via sensors
- If buffer >80% full for >30 minutes → MES alert: "Bottleneck at CNC Station 2"
- Advanced: MES reroutes parts to secondary line (if AGVs unlocked)

---

### H. AGV (Automated Guided Vehicle) - Tier 4 Unlock
**Function:** Flexible material transport, multi-path routing  
**Real-World Analog:** KIVA robots (Amazon), MiR100  
**Cost:** $45,000 each  
**Speed:** 1.2 m/s (faster than conveyors)  
**Capacity:** 100 kg payload  

**Advantages Over Conveyors:**
- **Dynamic Routing:** AGVs choose optimal path based on current congestion
- **Scalability:** Add more AGVs = more capacity (conveyors are fixed)
- **Flexibility:** Easy to reconfigure layout (no physical conveyor changes)

**MES Integration:**
- MES sends task: "Pick part from Buffer A, deliver to Assembly Station 3"
- AGV navigation: laser-guided or magnetic tape
- Collision avoidance: AGVs communicate to prevent crashes
- Fleet management: MES optimizes AGV assignments (minimize empty travel)

**Gameplay Impact:**
- Early game: Conveyor-based (cheaper, simpler)
- Mid-game: Hybrid (conveyors for main flow, AGVs for exceptions)
- Late-game: Full AGV fleet (maximum flexibility, high throughput)

**Functional Example:**
- Contract requires engine v1, v2, v3 on same line
- Conveyors route all parts identically (must handle all versions at every station)
- AGVs route selectively:
  - v1 → skip Station B (v1 doesn't need that op)
  - v2 → all stations
  - v3 → skip Station A, double-pass Station C
- Result: 20% faster average cycle time, reduced line congestion

---

## 2.2.3 Machine States (State Machine Model)

Every machine operates on a **finite state machine**:

```
IDLE → SETUP → RUNNING → COMPLETE → [MAINTENANCE | ERROR | IDLE]
```

**State Descriptions:**

| State | Description | Duration | Actions Available |
|-------|-------------|----------|-------------------|
| **IDLE** | Waiting for work order or material | Indefinite | Assign work order, schedule maintenance |
| **SETUP** | Worker configuring machine (tool change, program load) | 5-30 min | Speed up with skilled worker or MES automation |
| **RUNNING** | Actively processing part | Part-dependent | Monitor parameters, pause if needed |
| **COMPLETE** | Part finished, waiting for removal | Until part removed | Move part to next station |
| **MAINTENANCE** | Scheduled or unscheduled repair | 30 min - 4 hours | Pay maintenance cost, wait |
| **ERROR** | Fault detected (crash, sensor failure) | Until resolved | Diagnose, repair, restart |

**State Transitions (Triggers):**
- **IDLE → SETUP:** Work order assigned + material available + worker available
- **SETUP → RUNNING:** Setup complete
- **RUNNING → COMPLETE:** Cycle time elapsed + no errors
- **COMPLETE → IDLE:** Part removed, no more work orders queued
- **RUNNING → ERROR:** Fault condition (tool break, out-of-spec, crash)
- **ANY → MAINTENANCE:** Maintenance schedule reached OR breakdown

**Visual Indicators (Color-Coded Machine Sprites):**
- IDLE: Gray (dim)
- SETUP: Yellow (blinking)
- RUNNING: Green (animated - sparks, rotation)
- COMPLETE: Blue (steady)
- MAINTENANCE: Orange (wrench icon)
- ERROR: Red (flashing, alert icon)

---

## 2.2.4 Machine Parameter Calculations (Formulas)

### Cycle Time
```
ActualCycleTime = BaseCycleTime × WorkerEfficiency × ToolWearFactor × MESBonus

Where:
BaseCycleTime = Machine-specific (e.g., CNC: 10 min, Lathe: 8 min)
WorkerEfficiency = 0.7 (unskilled) to 1.3 (master)
ToolWearFactor = 1.0 (new tool) to 1.4 (worn tool)
MESBonus = 0.85 (optimized) to 1.0 (default)

Example (CNC with skilled worker, fresh tool, MES optimized):
= 10 min × 1.15 × 1.0 × 0.9 = 10.35 min ✓ Efficient!

Example (CNC with rookie worker, worn tool, no MES):
= 10 min × 0.75 × 1.3 × 1.0 = 9.75 min cycle BUT...
```

### Scrap Rate
```
ScrapRate = BaseScrap × (2 - WorkerSkillFactor) × ToolConditionFactor × (2 - MESAdjustment)

Where:
BaseScrap = Machine inherent (e.g., CNC: 3%, Assembly: 5%)
WorkerSkillFactor = 0.5 (skill 20) to 1.5 (skill 100)
ToolConditionFactor = 1.0 (new) to 2.5 (critically worn)
MESAdjustment = 0.5 (advanced MES) to 1.0 (no MES)

Example (CNC, skilled worker, good tool, basic MES):
= 3% × (2 - 1.4) × 1.1 × (2 - 0.8) = 3% × 0.6 × 1.1 × 1.2 = 2.38% ✓

Example (Assembly, unskilled worker, no tools issues, no MES):
= 5% × (2 - 0.6) × 1.0 × (2 - 1.0) = 5% × 1.4 × 1.0 × 1.0 = 7% ✗
```

### Tool Wear Progression
```
ToolWear += (CyclesRun / ToolLifespan) × MaterialHardnessFactor × SpeedAbuseFactor

Where:
ToolLifespan = 500 cycles (standard end mill)
MaterialHardnessFactor = 0.8 (aluminum) to 1.5 (hardened steel)
SpeedAbuseFactor = 1.0 (within spec) to 3.0 (severe overspeed)

Example (100 cycles on aluminum at optimal speed):
= (100 / 500) × 0.8 × 1.0 = 0.16 (16% wear) → Tool still good

Example (100 cycles on steel at 150% speed):
= (100 / 500) × 1.3 × 2.2 = 0.572 (57% wear) → Tool replacement soon!
```

### Machine Availability (OEE Component)
```
Availability = (PlannedProductionTime - Downtime) / PlannedProductionTime

Downtime = SetupTime + MaintenanceTime + BreakdownTime + IdleTime

Example (8-hour shift):
PlannedTime = 480 min
Setup = 30 min
Maintenance = 20 min
Breakdown = 0 min
Idle (waiting for material) = 60 min
Downtime = 110 min

Availability = (480 - 110) / 480 = 77.1%
```

### Overall Equipment Effectiveness (OEE)
```
OEE = Availability × Performance × Quality

Where:
Performance = (ActualOutput / TheoreticalMaxOutput)
Quality = (GoodParts / TotalParts)

Example (good operation):
Availability = 85%
Performance = 92% (some slowdowns)
Quality = 97% (low scrap)
OEE = 0.85 × 0.92 × 0.97 = 75.8% → **Industry Good**

Example (problematic operation):
Availability = 65% (frequent stops)
Performance = 78% (slow cycles)
Quality = 88% (high scrap)
OEE = 0.65 × 0.78 × 0.88 = 44.6% → **Needs Improvement**

World-Class OEE Target: >85%
```

---

## 2.3 Workers (Human Resources)

### 2.3.1 Worker Attributes (Detailed)

| Attribute | Range/Values | Gameplay Impact | Progression |
|-----------|--------------|-----------------|-------------|
| **Skill** | 1-100 | Cycle time efficiency (0.7x - 1.3x)<br>Error rate (15% - 1%) | +1 per 100 cycles worked on specialty |
| **Specialization** | Machining<br>Assembly<br>QC<br>Maintenance<br>R&D | +20% efficiency on matched tasks<br>-10% on mismatched tasks | Unlock via training programs |
| **Fatigue** | 0-100 | >50 = -10% efficiency<br>>75 = -20% efficiency + error rate +5%<br>100 = refuses to work | +10 per hour worked<br>-25 per hour rested |
| **Experience** | Level 1-50 | Unlocks certifications<br>Reduces setup time<br>Improves learning rate | +1 level per 5000 XP<br>XP from cycles + quality bonuses |
| **Certifications** | MES Coding<br>Atlas Certified<br>CMM Operator<br>Lean Six Sigma | Enable advanced tasks<br>Quality bonuses<br>Cross-training | Purchase with company funds + time investment |
| **Morale** | 0-100 | <50 = -15% efficiency<br>>80 = +10% efficiency | Affected by salary, safety, success |
| **Salary** | $2,500-$7,000/mo | Skill-dependent<br>Market rate ± player adjustment | Annual raises or skill-based increases |

---

### 2.3.2 Worker Specializations (Deep Dive)

**1. Machining Specialist**
- **Primary Machines:** CNC, Lathe, Grinder
- **Key Skills:**
  - Tool selection and setup
  - NC program understanding (reads G-code)
  - Dimensional inspection (micrometers, calipers)
- **Bonuses:**
  - +20% setup speed on CNC/Lathe
  - -15% tool wear (careful operation)
  - Can spot programming errors before crash
- **Career Path:** Operator → Senior Operator → Lead Machinist → CNC Programmer
- **Salary Range:** $3,000 - $5,500

**2. Assembly Specialist**
- **Primary Stations:** Assembly, Atlas Nutrunner, Final Assembly
- **Key Skills:**
  - Torque technique
  - Sequence memorization
  - Component recognition
- **Bonuses:**
  - +25% assembly speed
  - -50% torque errors
  - Can work without work instructions (if experienced)
- **Career Path:** Assembler → Senior Assembler → Team Lead → Assembly Engineer
- **Salary Range:** $2,500 - $4,500

**3. QC Inspector**
- **Primary Stations:** QC Station, CMM, Vision System
- **Key Skills:**
  - Measurement precision
  - Statistical analysis (SPC charts)
  - Defect identification
- **Bonuses:**
  - +30% inspection speed
  - -80% false positive/negative rate
  - Can perform root cause analysis (suggests fixes to player)
- **Career Path:** Inspector → Senior Inspector → QC Engineer → Quality Manager
- **Salary Range:** $3,200 - $5,800

**4. Maintenance Technician**
- **Primary Tasks:** Machine repair, preventive maintenance, troubleshooting
- **Key Skills:**
  - Mechanical repair
  - Electrical diagnostics
  - PLC programming (advanced)
- **Bonuses:**
  - -40% maintenance time
  - -30% breakdown probability (proactive inspections)
  - Can perform maintenance without halting production (some cases)
- **Career Path:** Apprentice → Technician → Senior Tech → Maintenance Engineer
- **Salary Range:** $3,500 - $6,500

**5. R&D Engineer**
- **Primary Tasks:** Product design, process improvement, simulation
- **Key Skills:**
  - CAD/CAM
  - Material science
  - Process optimization
- **Bonuses:**
  - -25% R&D project time
  - +15% success probability
  - Generates IP (patents) that provide ongoing revenue
- **Career Path:** Junior Engineer → Engineer → Senior Engineer → Principal Engineer
- **Salary Range:** $4,500 - $7,500

---

### 2.3.3 Worker Assignment & Scheduling

**Assignment Rules:**
- **1 Worker per Station (default):** Most machines require 1 dedicated operator
- **2+ Workers per Station (advanced):** High-throughput or safety-critical operations
- **Floating Workers:** Can cover multiple idle stations (requires cross-training)
- **Team Leads:** 1 lead per 8 workers (provides +5% team-wide efficiency)

**Shift System:**
- **Single Shift (8 hours):** 6am-2pm, cheapest labor cost
- **Double Shift (16 hours):** Add 2pm-10pm shift, +15% wages (shift differential)
- **Triple Shift (24 hours):** Add 10pm-6am shift, +30% wages (night differential)
- **Overtime:** Beyond 40 hours/week = 1.5× pay

**Fatigue Management:**
- **Rest Breaks:** 15-min break every 2 hours (regulatory requirement)
- **Shift Handoff:** 15-min overlap between shifts (knowledge transfer)
- **Days Off:** Workers require 2 days off per week (or fatigue → 100)

**Cross-Training:**
- **Single-Skilled:** 100% efficiency on primary specialty, 50% on others
- **Dual-Skilled:** 100% on primary, 85% on secondary (requires training investment)
- **Multi-Skilled:** 95% on all specialties (rare, expensive, late-game)

**Functional Example (Shift Optimization Puzzle):**
```
Scenario: Contract requires 24-hour production (triple shift)

Option A: Hire 24 workers (3 shifts × 8 workers)
- Cost: 24 × $3,500 avg × 1.15 shift premium = $96,600/month
- Advantage: No fatigue issues, consistent quality
- Disadvantage: High fixed labor cost

Option B: Hire 16 workers, use overtime + cross-training
- Cost: 16 × $3,500 + overtime ~$15,000 = $71,000/month
- Advantage: Lower fixed cost
- Disadvantage: Fatigue accumulation after 2 weeks → quality drops

Option C (Strategic): Hire 20 workers, 2 shifts + weekend overtime
- Runs 16 hours/day weekdays, 8 hours/day weekends
- Produces 23.5 hours equivalent per day (due to higher efficiency)
- Cost: ~$78,000/month
- Advantage: Balance of cost and quality
- Disadvantage: Requires meticulous scheduling

Player Decision: Depends on contract margin, duration, and worker availability.
```

---

### 2.3.4 Worker Progression & Training

**Experience Gain:**
```
XP_per_cycle = BaseCycleXP × (1 + SpecialtyMatch × 0.5) × (1 + QualityBonus)

Where:
BaseCycleXP = 10 XP
SpecialtyMatch = 1 if worker specialty matches machine, 0 otherwise
QualityBonus = 0.2 if part passes QC, 0 if scrapped

Example (Machining specialist on CNC, part passes QC):
= 10 × (1 + 1 × 0.5) × (1 + 0.2) = 10 × 1.5 × 1.2 = 18 XP

Example (Assembly worker on QC station, part scrapped):
= 10 × (1 + 0 × 0.5) × (1 + 0) = 10 XP (slow learning, wrong specialty)
```

**Skill Increase:**
```
Every 100 cycles on specialty machine: +1 skill (max 100)
Every 200 cycles on non-specialty: +1 skill (max 70)
```

**Training Programs (Player-Initiated):**

| Program | Duration | Cost | Effect |
|---------|----------|------|--------|
| Basic CNC Operation | 2 weeks | $2,000 | Unlock CNC specialty |
| Atlas Nutrunner Certification | 1 week | $1,500 | +30% torque accuracy |
| CMM Operation | 1 week | $1,800 | Enable QC station operation |
| MES Block Coding | 2 weeks | $3,000 | Worker can write basic MES rules |
| Lean Six Sigma Yellow Belt | 4 weeks | $5,000 | +10% process efficiency suggestions |
| Advanced PLC Programming | 6 weeks | $8,000 | Worker can troubleshoot machine errors |

**Functional Example (Training ROI):**
```
Worker: Jane (Skill 55, Assembly Specialist)
Current Performance: 8% error rate on Atlas Nutrunner tasks

Decision: Send to "Atlas Certification" training
- Cost: $1,500 + 1 week lost productivity (~$1,000) = $2,500 total
- Result: Error rate drops to 3%, +20% speed on nutrunner tasks

Contract Impact:
- Before training: 100 engines, 8 failures = $4,000 scrap cost
- After training: 100 engines, 3 failures = $1,500 scrap cost
- Savings: $2,500 per 100 engines → Training pays for itself in 100 engines (~2 weeks)

Strategic Value: Worker can now handle precision assembly on multiple products, 
increasing factory flexibility.
```

---

### 2.3.5 Worker Morale & Retention

**Morale Factors:**

| Factor | Impact on Morale | Player Control |
|--------|------------------|----------------|
| **Salary (vs. market rate)** | -20 (underpaid) to +20 (overpaid) | Adjust wages |
| **Workplace Safety** | -15 (unsafe) to +10 (excellent) | Invest in safety equipment, training |
| **Job Variety** | -10 (monotonous) to +15 (cross-trained, rotated) | Job rotation, cross-training |
| **Success Rate** | -20 (constant failures) to +25 (perfect deliveries) | Improve processes, MES quality |
| **Workload** | -25 (overworked) to +10 (balanced) | Hire more workers, manage overtime |
| **Recognition** | -5 (ignored) to +15 (bonuses, promotions) | Award bonuses, promote to team lead |

**Morale Effects:**
- **<30 (Critical Low):** -25% efficiency, 15% chance to quit per month
- **30-50 (Low):** -15% efficiency, 5% quit chance
- **50-70 (Neutral):** Standard performance
- **70-85 (Good):** +5% efficiency, recruits recommend company (cheaper hiring)
- **>85 (Excellent):** +15% efficiency, zero turnover, workers suggest improvements

**Turnover Costs:**
- **Hiring Replacement:** $3,000 recruitment + 2-week onboarding (low productivity)
- **Knowledge Loss:** New worker starts at Skill 30-40 regardless of predecessor
- **Team Disruption:** -5% efficiency for team for 1 month (adjustment period)

**Retention Strategies:**
- **Competitive Pay:** Match or exceed market rate (+10% = happy workers)
- **Career Progression:** Promote high-performers to team leads (+15 morale)
- **Profit Sharing:** End-of-year bonus (1-5% of company profit) → +20 morale
- **Work-Life Balance:** Avoid excessive overtime, provide predictable schedules

---

## 2.4 Conveyors & Material Flow (Advanced Mechanics)

### 2.4.1 Conveyor Types & Specifications

**A. Belt Conveyor**
- **Use Case:** Lightweight parts (<50 kg), smooth surfaces
- **Speed:** 0.3-0.8 m/s (adjustable)
- **Width:** 300mm (standard), 600mm (wide parts)
- **Cost:** $400/meter
- **Advantages:** Quiet, gentle on parts, low maintenance
- **Disadvantages:** Limited weight capacity, can't handle sharp edges

**B. Roller Conveyor**
- **Use Case:** Heavy parts (50-200 kg), palletized loads
- **Speed:** 0.2-0.5 m/s
- **Width:** 500mm
- **Cost:** $650/meter
- **Advantages:** High capacity, durable
- **Disadvantages:** Noisy, higher power consumption

**C. Chain Conveyor**
- **Use Case:** Very heavy parts (>200 kg), automotive body panels
- **Speed:** 0.1-0.3 m/s
- **Width:** 800mm
- **Cost:** $900/meter
- **Advantages:** Extreme durability, handles large loads
- **Disadvantages:** Slow, requires lubrication, high maintenance

**D. Overhead Conveyor**
- **Use Case:** Floor space savings, parts can swing (paint lines)
- **Speed:** 0.4 m/s
- **Cost:** $1,200/meter (includes supports)
- **Advantages:** Doesn't occupy floor space, good for multi-level layouts
- **Disadvantages:** Complex installation, limited to certain part types

---

### 2.4.2 Material Flow Principles

**Push vs. Pull Systems:**

**Push System (Early Game Default):**
- Machines produce as fast as possible
- Parts pushed downstream regardless of demand
- Risk: WIP accumulation, buffer overflow, imbalanced flow

**Pull System (Lean/JIT, Unlock Tier 3):**
- Downstream stations "pull" parts from upstream only when needed
- Kanban signals control production
- Benefits: Minimal WIP, balanced flow, lower inventory costs

**Kanban Implementation (In-Game):**
```
Buffer A → Machine 1 → Buffer B → Machine 2 → Output

Pull Signal:
- Buffer B has space for 10 parts
- Currently holds 3 parts
- Send signal to Machine 1: "Produce 7 parts"
- Machine 1 produces exactly 7, then stops (waits for next signal)

Result: 
- Buffer never overfills
- Machine 1 never wastes time producing unneeded parts
- System automatically balances to slowest machine (bottleneck)
```

**Visual Flow Indicators:**
- **Green Arrow:** Parts flowing smoothly (<50% buffer)
- **Yellow Arrow:** Moderate congestion (50-80% buffer)
- **Red Arrow:** Severe backup (>80% buffer, upstream machines slowing)
- **Dashed Line:** Starved - no parts available (downstream machines idle)

---

### 2.4.3 Routing & Branching Logic

**Simple Linear Flow:**
```
Receiving → Lathe → CNC → Assembly → QC → Dispatch
(All parts follow same path)
```

**Branching Flow (Multi-Product):**
```
Receiving → Lathe → [Decision Point]
                    ↓
                    ├→ CNC (for engine type A)
                    ├→ Grinder (for engine type B)
                    └→ Skip (type C doesn't need machining)
                    ↓
                    [Merge Point] → Assembly → QC → Dispatch
```

**MES-Controlled Routing:**
```
At Decision Point, MES reads part RFID tag:
- Part ID: ENG-A-00123
- Product Type: A
- MES Rule: IF productType == "A" THEN route = "CNC" ELSE IF "B" THEN "Grinder"
- Conveyor diverter actuates to correct path
```

**Functional Example (Mixed-Model Line Challenge):**
```
Scenario: Produce 3 engine variants on 1 line

Engine v1: Lathe → CNC → Assembly (simple)
Engine v2: Lathe → CNC → Grinder → Assembly (precision)
Engine v3: Lathe → Assembly (basic, no CNC)

Challenge:
- If all 3 types mixed randomly on line, CNC and Grinder underutilized
- v3 parts wait unnecessarily at CNC (which skips them)

MES Solution (Player-Configured):
- Batch v1 and v2 together (both use CNC)
- Run v3 in separate batch (express lane, skip CNC/Grinder stations entirely)
- AGVs (if unlocked) can dynamically route v3 past CNC to Assembly directly

Result:
- 18% reduction in average cycle time
- CNC/Grinder utilization increases from 60% to 85%
- Player achieves "Mixed-Model Master" achievement
```

---

## 2.5 Factory Zones & Layout Optimization

### 2.5.1 Zone Functions

**Receiving Zone (Blue):**
- **Purpose:** Material intake, inspection, quarantine
- **Equipment:** Forklift docks, incoming QC station
- **MES Integration:** ERP sends advance shipment notice (ASN) → MES prepares receiving checklist
- **Best Practices:**
  - Place near entrance (minimize travel distance)
  - Dedicated QC station (catch defects before production)
  - FIFO organization (use oldest material first)

**Machining Zone (Gray):**
- **Purpose:** Subtractive manufacturing (CNC, Lathe, Grinder)
- **Characteristics:**
  - Noisy (requires separation from QC/R&D)
  - Generates chips/coolant (cleaning required)
  - High power consumption (electrical planning)
- **Layout Tip:** Group similar machines (all CNCs together) for shared tooling, worker efficiency

**Assembly Zone (Green):**
- **Purpose:** Component integration, bolt tightening, testing
- **Characteristics:**
  - Clean environment (low dust)
  - Good lighting (worker precision)
  - Ergonomic workstations (reduce fatigue)
- **Layout Tip:** Linear flow for high volume, cellular for low volume / high variety

**QC Zone (Yellow):**
- **Purpose:** Inspection, testing, rework
- **Characteristics:**
  - Climate-controlled (dimensional stability)
  - Isolated from vibration (precision measurement)
  - Good documentation (test records)
- **Layout Tip:** Place QC after each major operation (catch defects early) AND before dispatch (final verification)

**Storage / WIP Zone (Orange):**
- **Purpose:** Buffers, inventory, staging areas
- **Challenge:** WIP is "frozen cash" - minimize without starving production
- **Best Practices:**
  - FIFO lanes (prevent old parts languishing)
  - Clear labeling (RFID tags, visual kanban cards)
  - Dynamic sizing (adjust buffer capacity based on demand variability)

**Dispatch Zone (Purple):**
- **Purpose:** Final packaging, shipping, customer handoff
- **Equipment:** Packing stations, shipping docks
- **MES Integration:** ERP tracks shipped quantities, updates contract fulfillment
- **Best Practices:** Staging area for different customers, quality hold area (suspect parts quarantined)

**R&D Zone (Cyan, Phase 4+):**
- **Purpose:** Product development, prototyping, testing
- **Equipment:** CAD workstations, 3D printers, test benches
- **Best Practices:** Separate from production (avoid contamination), close to engineering offices

---

### 2.5.2 Layout Strategies

**Linear Layout (High Volume, Low Variety):**
```
[Receiving] → [Lathe] → [CNC] → [Assembly] → [QC] → [Dispatch]
            ←—————— Rework Loop ——————←
```
- **Pros:** Simple, easy to balance, high throughput
- **Cons:** Inflexible, large footprint, WIP buildup if unbalanced

**Cellular Layout (Low Volume, High Variety):**
```
      ┌→ [Cell A: v1 engines] →┐
      |    (Lathe+CNC+Assy)     |
[Rec]─┼→ [Cell B: v2 engines] →┼→ [QC] → [Dispatch]
      |    (CNC+Grinder+Assy)   |
      └→ [Cell C: v3 engines] →┘
           (Lathe+Assy only)
```
- **Pros:** Flexible, cross-trained workers, low WIP
- **Cons:** Higher worker skill requirement, potential machine duplication

**U-Shaped Layout (Lean Manufacturing):**
```
[Receiving]
    ↓
[Lathe] → [CNC] ┐
    ↑             ↓
[Dispatch] ← [Assembly] ← [QC]
```
- **Pros:** Minimal travel distance, worker can monitor multiple stations, easy communication
- **Cons:** Requires careful space planning, not suitable for all factory sizes

**Hybrid / Modular (Late-Game):**
```
Main Line (high volume): Linear layout for v1 engines
Flex Cells (low volume): Cellular for v2, v3, prototypes
AGV Network: Connects all zones dynamically
```
- **Pros:** Best of both worlds, scalable
- **Cons:** Complex to manage, requires advanced MES

---

### 2.5.3 Layout Optimization Challenges (Gameplay Puzzles)

**Challenge 1: "The Bottleneck Bypass"**
```
Situation:
- Current layout: Lathe → CNC → Grinder → Assembly
- CNC is bottleneck (8 parts/hr vs. Lathe 12 parts/hr)
- Budget: $50,000

Options:
A. Buy 2nd CNC ($35k) → doubles CNC capacity, solves bottleneck
B. Reroute low-precision parts to skip CNC ($5k conveyors + MES logic) → reduces CNC load 30%
C. Upgrade existing CNC ($25k) + optimize MES ($0) → +40% CNC speed

Analysis:
- Option A: Highest cost, future-proof (can handle growth)
- Option B: Cheapest, but adds routing complexity, requires MES skill
- Option C: Middle ground, best ROI if CNC utilization <70%

Strategic Consideration: What's the contract pipeline? If more high-volume contracts incoming, A is best. If variety increasing, B teaches valuable skills.
```

**Challenge 2: "The Space Crunch"**
```
Situation:
- Factory size: 30×30 cells (900m²)
- Current usage: 750m² (83%)
- New contract requires +30% capacity
- Expansion cost: $50,000 per 10×10 cell block

Options:
A. Expand factory (buy more land) → $150k for 30×10 extension
B. Go vertical (overhead conveyors, mezzanine assembly) → $80k, same footprint
C. Relocate to larger facility → $500k upfront, but better long-term layout

Optimization Puzzle:
- Can player rearrange existing layout to free up 15% space?
- Identify wasted buffer zones, redundant conveyors, poorly placed machines
- MES can simulate different layouts (Tier 4 unlock: "Layout Simulator")

Educational Value: Teaches players about facility planning, capital allocation, growth strategy.
```

---

## 2.6 Integration Examples (Pulling It All Together)

### Example 1: Multi-Product Line with MES Orchestration

**Scenario:** Assemble 3 engine variants on shared line

**Products:**
- **v1 (Basic):** 200 units/week, simple assembly
- **v2 (Standard):** 150 units/week, requires Atlas Nutrunner precision
- **v3 (Premium):** 50 units/week, extra machining + QC

**Line Setup:**
```
[Receiving] → [Lathe] → [CNC] → [Buffer A] → [Assembly] → [Atlas] → [QC] → [Buffer B] → [Dispatch]
```

**MES Rules (Player-Created via Block Editor):**

**Rule 1: Dynamic Torque Assignment**
```
WHEN Part arrives at Atlas Nutrunner
IF Part.version == "v1" THEN
  Nutrunner.setTorque(75, tolerance=3)
ELSE IF Part.version == "v2" THEN
  Nutrunner.setTorque(85, tolerance=1.5)
ELSE IF Part.version == "v3" THEN
  Nutrunner.setTorque(95, tolerance=1, angle=60)
END
```

**Rule 2: Routing Logic**
```
AT Buffer A Decision Point
IF Part.version == "v3" THEN
  Route to [Advanced QC Station]
ELSE
  Route to [Standard QC]
END
```

**Rule 3: Sequencing Optimization**
```
PRODUCTION SCHEDULER
Batch similar versions together to minimize changeovers:
- Morning shift: 100× v1 (4 hours)
- Midday: 75× v2 (4 hours)
- Afternoon: 25× v3 (2 hours)
- Repeat pattern

Result: Setup time reduced 40% vs. random sequencing
```

**Metrics (Player Dashboard Display):**
```
Line Performance Summary:
- OEE: 78.2% (Availability: 85%, Performance: 92%, Quality: 97%)
- Throughput: 387 units/week (target: 400)
- Bottleneck: Atlas Nutrunner (92% utilization)
- Scrap Rate: 2.8% (acceptable, target <3%)
- WIP: 42 units (Buffer A: 28, Buffer B: 14)

Recommendations (MES-Generated):
1. Add 2nd Atlas Nutrunner to increase capacity 18%
2. Cross-train Worker #4 on CNC to cover breaks (reduce idle time)
3. Tighten v1 torque tolerance to 2Nm to reduce QC sampling
```

**Player Response:**
- Accepts Recommendation #2 (cheap, immediate impact)
- Postpones #1 until next contract (capex decision)
- Experiments with #3 using MES simulation (risk-free testing)

---

# 3. MES SYSTEM (Manufacturing Execution System)

## 3.1 MES Overview & Philosophy

The **MES (Manufacturing Execution System)** is the game's **central orchestration layer** that bridges high-level business decisions (contracts, planning) with low-level machine execution (PLCs, sensors). 

**Design Philosophy:**
- **Optional Depth:** Casual players can succeed using GUI presets without touching MES coding
- **Progressive Mastery:** Advanced players unlock significant competitive advantages through MES optimization
- **Real-World Authenticity:** Based on ISA-95 standard and MESA-11 functions
- **Educational Value:** Players learn actual manufacturing principles while having fun

**Player Perception:**
- **Casual View:** "MES is like autopilot for my machines - set it and forget it"
- **Strategic View:** "MES is my efficiency multiplier - 10 hours learning = 20% permanent throughput boost"
- **Expert View:** "MES is my competitive moat - custom scripts give me capabilities competitors can't match"

---

## 3.2 ISA-95 Hierarchy (Player-Facing Abstraction)

The game uses the **ISA-95 standard** to structure manufacturing control levels:

```
┌─────────────────────────────────────────────────┐
│ LEVEL 4: ERP (Enterprise Resource Planning)    │
│ Player sees: Contract Manager, Economy Panel    │
│ Function: What to make, when, for whom          │
└────────────────┬────────────────────────────────┘
                 ↓ Work Orders, Material Requests
┌────────────────┴────────────────────────────────┐
│ LEVEL 3: MES (Manufacturing Execution System)   │
│ Player sees: MES Dashboard, Rule Editor         │
│ Function: How to make it, optimize production   │
└────────────────┬────────────────────────────────┘
                 ↓ Machine Commands, Telemetry
┌────────────────┴────────────────────────────────┐
│ LEVEL 2: SCADA/HMI (Supervisory Control)        │
│ Player sees: Machine Detail Panels              │
│ Function: Monitor machines, display status      │
└────────────────┬────────────────────────────────┘
                 ↓ Setpoints, Sensor Data
┌────────────────┴────────────────────────────────┐
│ LEVEL 1: PLC (Programmable Logic Controller)    │
│ Player sees: (Abstracted - automatic)           │
│ Function: Execute NC programs, control motors   │
└────────────────┬────────────────────────────────┘
                 ↓ Motor Commands, Sensor Readings
┌────────────────┴────────────────────────────────┐
│ LEVEL 0: Physical Process                       │
│ Player sees: Animated machines, particle FX     │
│ Function: Cut metal, tighten bolts, move parts  │
└─────────────────────────────────────────────────┘
```

**Gameplay Translation:**
- **Level 4 (ERP):** Player assigns contract → generates work orders
- **Level 3 (MES):** Player creates rules → MES sends commands to machines
- **Level 2 (SCADA):** Player views machine status → sees real-time data
- **Levels 0-1:** Abstracted → machines "just work" based on MES commands

---

## 3.3 MES Core Functions (MESA-11 Model)

The **Manufacturing Enterprise Solutions Association (MESA)** defined 11 core MES functions. Here's how each appears in-game:

### 3.3.1 Resource Allocation and Status

**Function:** Track and allocate machines, workers, materials, tools

**Player Interface:**
- **Resource Dashboard** shows:
  - Machines: IDLE / SETUP / RUNNING / MAINTENANCE / ERROR
  - Workers: Available / Assigned / Break / Training
  - Materials: Stock levels, incoming shipments
  - Tools: Quantity, wear status, location

**MES Automation:**
```
Example: Player clicks "Start Production: 50 Engine Blocks"

MES Resource Check:
✓ CNC_01: Available (idle, 2% tool wear)
✓ Worker_Jane: Skill 75, Machining specialty
✓ Material: 52 aluminum billets in stock
✗ Tool: 12mm end mill - all 3 tools >80% wear

MES Alert: "Tool replacement recommended before starting"
Player Options:
  A. Replace tools ($600, 20 min delay) → Optimal
  B. Proceed (risk +8% scrap rate)
  C. Schedule for later (postpone production)
```

**Advanced Feature (Tier 3+):** 
- MES can auto-reserve resources for upcoming orders
- Prevents resource conflicts between concurrent jobs

---

### 3.3.2 Operations/Detailed Scheduling

**Function:** Sequence work orders to optimize machine utilization and meet deadlines

**Scheduling Strategies (Player-Selectable):**

**A. FIFO (First-In-First-Out):**
- Simplest, fairest
- Good for: Stable demand, similar job sizes
- Downside: May miss urgent deadlines

**B. Shortest Job First (SJF):**
- Prioritizes quick jobs
- Good for: Maximizing completed orders
- Downside: Large jobs may starve

**C. Critical Ratio (Deadline-Driven):**
```
CriticalRatio = (Deadline - CurrentTime) / RemainingProcessTime

Priority Queue (lowest CR first):
Order A: CR = 0.8 → URGENT (deadline approaching, long job)
Order B: CR = 2.0 → Normal
Order C: CR = 4.5 → Relaxed (plenty of time)
```
- Good for: Contract-heavy gameplay, penalty avoidance
- Downside: Requires constant re-calculation

**MES Automation Example:**
```
Player-Created Rule (Block Editor):
IF TimeToDeadline < 24 hours THEN
  UseStrategy("CriticalRatio")
ELSE IF AllOrdersSimilar THEN
  UseStrategy("FIFO")
ELSE
  UseStrategy("SJF")
END

Effect: MES automatically adjusts scheduling strategy based on factory state
```

**Visual Representation (In-Game UI):**
```
┌─ PRODUCTION SCHEDULER ─────────────────────┐
│                                            │
│ Timeline (Next 48 Hours):                  │
│ │──[Order 1]──│──[Order 3]──│──[Order 2]──│
│ 0h          16h           32h            48h│
│                                            │
│ Order Queue:                               │
│ 1. Engine v2 x100 (CR: 0.8) ⚠ URGENT       │
│ 2. Engine v1 x50  (CR: 2.1) ○ Normal       │
│ 3. Engine v3 x25  (CR: 4.2) ○ Relaxed      │
│                                            │
│ [Auto-Schedule] [Manual Adjust] [Simulate] │
└────────────────────────────────────────────┘
```

---

### 3.3.3 Dispatching Production Units

**Function:** Send work instructions to machines and operators

**Digital Work Instructions (HMI Display):**

When a worker arrives at a station, MES pushes instructions to the HMI screen:

```
┌─ WORK ORDER: WO-2025-1234 ────────────────┐
│ Product: Engine Block Assembly v2         │
│ Serial: ENG-v2-S00523                     │
│ Worker: Carlos_W018                       │
├───────────────────────────────────────────┤
│ STEP 4 of 12: Cylinder Head Bolting      │
│                                           │
│ Tools Required:                           │
│  • Atlas Nutrunner #2                    │
│  • Torque: 85 Nm ± 1 Nm                  │
│  • Angle: 60° (after seating)            │
│                                           │
│ Bolt Sequence (CRITICAL):                │
│  1. A1 (front-left)  [Diagram]           │
│  2. A4 (rear-right)   │ │                │
│  3. A2 (front-right)  │ │                │
│  4. A3 (rear-left)   └─┘                 │
│                                           │
│ Safety: Torque verification required     │
│ QC: MES will log all torque values       │
│                                           │
│ [✓ Start Step]                           │
└───────────────────────────────────────────┘
```

**Worker clicks "Start Step":**
1. MES activates Atlas Nutrunner, pre-configures to 85 Nm ± 1 Nm
2. Nutrunner locks out-of-sequence bolts (enforces A1 → A4 → A2 → A3)
3. As each bolt is tightened, nutrunner reports actual torque to MES
4. MES displays real-time checklist:
   ```
   ✓ Bolt A1: 85.2 Nm, 59° - PASS
   ✓ Bolt A2: 84.9 Nm, 61° - PASS
   ✓ Bolt A3: 85.0 Nm, 60° - PASS
   ⧗ Bolt A4: [In Progress...]
   ```
5. All bolts complete → MES advances to Step 5

**Benefits:**
- Zero worker errors on torque specs
- Full traceability (every bolt logged)
- Enforced sequence (impossible to skip steps)
- Real-time quality assurance

---

### 3.3.4 Document Control

**Function:** Manage work instructions, NC programs, drawings, SOPs

**Document Library (MES-Managed):**
- **NC Programs:** G-code for CNC/Lathe (e.g., `PROG_ENG_BLK_V2.nc`)
- **Assembly Instructions:** Step-by-step guides with photos/videos
- **Quality Specs:** Tolerance drawings, inspection procedures
- **Safety Procedures:** Lockout/tagout, hazmat handling

**Version Control:**
- Only **latest-approved** documents are accessible
- Obsolete versions archived (read-only, for reference)
- ECO (Engineering Change Order) triggers automatic updates

**ECO Integration Example:**
```
Event: ECO-2025-042 "Crankshaft v1 → v2 (Material Change)"

MES Actions (Automatic):
1. Archive old documents:
   - CRNK-v1-NCProgram.nc → status "OBSOLETE"
   - CRNK-v1-AssemblyInst.pdf → status "OBSOLETE"
   
2. Activate new documents:
   - CRNK-v2-NCProgram.nc → status "ACTIVE"
   - CRNK-v2-AssemblyInst.pdf → status "ACTIVE"
   - Updated torque spec: 85 Nm → 95 Nm
   
3. Alert affected stations:
   - CNC_02: "New NC program available - load before next run"
   - Assembly_05: "Review updated torque specs before shift"
   
4. Flag workers for training:
   - Workers assigned to crankshaft ops → "Training Required: CRNK-v2"
   - Player must schedule 2-hour training session
   
5. Update MES rules:
   - Auto-update torque rule: IF part.type = "CRNK-v2" THEN torque = 95

Player Response Required:
- Click "Accept ECO" → MES handles updates
- Delay/Ignore → Production continues with OLD specs → Quality failures
```

**Gameplay Impact:**
- **Accept ECO promptly:** Smooth transition, no quality issues
- **Delay ECO:** Risk producing defective parts, scrap costs increase
- **Ignore ECO:** Customer rejects shipment, contract penalties

---

### 3.3.5 Data Collection and Acquisition

**Function:** Gather machine data, operator inputs, sensor readings

**Automatic Data Collection (OPC-UA):**

MES continuously collects data from machines via **OPC-UA protocol**:

```
Example: CNC_02 Telemetry Stream (1 Hz update rate)

{
  "machineID": "CNC_02",
  "timestamp": "2025-12-21T14:32:18Z",
  "status": "Running",
  "currentPart": "ENG-BLK-v2-S00145",
  "operation": "Finishing_Pass_3_of_5",
  "progress": 0.68,  // 68% complete
  
  "parameters": {
    "spindleRPM": 2487,  // Target: 2500
    "feedRate": 248,     // Target: 250 mm/min
    "coolantFlow": 12.5, // L/min
    "cutDepth": 0.5      // mm
  },
  
  "sensors": {
    "cuttingForce": 520,    // N (target: 500 ± 50)
    "temperature": 42.3,    // °C (coolant exit temp)
    "vibration": 2.8,       // mm/s
    "powerConsumption": 7.2 // kW
  },
  
  "tooling": {
    "currentTool": "EM-06-0089",
    "toolWear": 0.34,  // 34% worn
    "cyclesOnTool": 170
  }
}
```

**MES Processing:**
- Updates machine status overlay (color-coded)
- Calculates remaining cycle time: `(TotalCycles - Progress) × AvgCycleTime`
- Logs power consumption for cost tracking
- Monitors tool wear → schedules replacement at 70%
- Detects anomalies (e.g., cutting force spike → tool dulling)

**Manual Data Entry:**
- Visual inspection results (worker selects defect type from dropdown)
- Material lot numbers (barcode scan or manual entry)
- Setup notes (worker comments on issues/fixes)

**Data Types & Uses:**

| Data Category | Source | Frequency | Use Case |
|--------------|--------|-----------|----------|
| **Production Counts** | Machine PLC | Per cycle (~10 min) | Contract progress tracking |
| **Quality Metrics** | QC Station | Per part (100%) or sample (5-20%) | Scrap rate, SPC trend analysis |
| **Downtime Events** | Machine PLC | Real-time (event-triggered) | OEE calculation, root cause analysis |
| **Material Usage** | ERP Integration | Per work order start | Inventory depletion, cost allocation |
| **Worker Activity** | HMI login/logout | Per shift | Labor cost, efficiency analysis |
| **Energy Consumption** | Power meters | Per minute | Utility costs, sustainability metrics |

---

### 3.3.6 Labor Management

**Function:** Track worker skills, attendance, productivity, certifications

**Worker Database (MES-Managed):**
```
┌─ WORKER PROFILE: Jane_W042 ───────────────┐
│                                           │
│ Current Assignment: CNC_02                │
│ Shift: Morning (6am-2pm)                  │
│ Status: Working (Logged in 5h 42m ago)    │
│                                           │
│ Skills:                                   │
│  • Machining: ████████░░ 85/100          │
│  • Assembly:  ███░░░░░░░ 35/100          │
│  • QC:        ██████░░░░ 60/100          │
│                                           │
│ Certifications:                           │
│  ✓ CNC Operation (Level 2)               │
│  ✓ Blueprint Reading                     │
│  ✗ Atlas Nutrunner (Not certified)       │
│                                           │
│ Performance (Last 30 Days):               │
│  • Avg Cycle Time: 11.2 min (vs 12 target)│
│  • Error Rate: 2.1% (excellent)          │
│  • Parts Produced: 1,247                 │
│  • Attendance: 100% (perfect)            │
│                                           │
│ Training History:                         │
│  • CNC Advanced (Completed 2025-11-05)   │
│  • Lean Six Sigma Yellow (In Progress)   │
│                                           │
│ [Assign] [Train] [Performance Review]    │
└───────────────────────────────────────────┘
```

**Skill Matrix (Team View):**
```
           CNC  Lathe Assembly QC  Nutrunner Maint
Jane       ██   ██    █       ██   ░         ░
Carlos     █    ░     ███     ░    ███       ░
Maria      ░    ░     ██      ███  ██        █
David      ░    ░     █       ██   █         ███

Legend: ███ Expert (100%), ██ Skilled (70-99%), █ Basic (40-69%), ░ Untrained

MES Recommendations:
⚠ No expert on CNC - consider cross-training Carlos
⚠ Only Maria can cover Maintenance - single point of failure
✓ Assembly well-covered (all workers have basic+ skills)
```

**MES Optimization:**
- Suggests optimal worker-to-machine assignments based on skill match
- Flags single points of failure (only 1 worker trained on critical equipment)
- Recommends cross-training investments
- Tracks fatigue → prevents assignments that would exceed safe limits

**Time & Attendance:**
- Clock in/out via HMI touchscreen
- Break tracking (regulatory compliance: 15 min every 2 hours)
- Overtime calculations (1.5× pay after 40 hours/week)

---

### 3.3.7 Quality Management

**Function:** Track defects, perform root cause analysis, implement corrective actions

**Defect Tracking & Pareto Analysis:**

MES logs every scrapped part with detailed metadata:

```
Scrap Record: Part ENG-v2-S00156
- Timestamp: 2025-12-21 10:23:41
- Defect Type: Dimensional_Out_of_Spec
- Failed Feature: Cylinder bore diameter
- Measured: 85.08 mm (Spec: 85.00 ± 0.05 mm)
- Machine: CNC_02
- Operator: Worker_Jane
- Tool: EM-12-0042 (Wear: 68%)
- Material Lot: AL-6061-LOT-4523
- NC Program: PROG_ENG_BLK_V2.nc (Version 2.1)
```

**MES Pareto Analysis (Last 100 Parts):**
```
┌─ SCRAP ROOT CAUSE ANALYSIS ───────────────┐
│                                           │
│ Defect Types:                             │
│ 1. Dimensional Out-of-Spec:  38 (38%) ████│
│ 2. Surface Finish Poor:      22 (22%) ███ │
│ 3. Tool Mark / Burr:         15 (15%) ██  │
│ 4. Wrong Torque:             12 (12%) ██  │
│ 5. Material Defect:           8 (8%)  █   │
│ 6. Other:                     5 (5%)  █   │
│                                           │
│ Correlation Analysis (Dimensional):       │
│ Machine:    85% on CNC_02 (vs 15% CNC_01)│
│ Shift:      70% during Shift 2            │
│ Tool Wear:  60% correlated with >75% wear│
│                                           │
│ MES Recommendations:                      │
│ 1. Inspect CNC_02 calibration ⚠ Priority│
│ 2. Train Worker_Bob (Shift 2 operator)   │
│ 3. Reduce tool interval: 500→400 cycles  │
│                                           │
│ [Implement All] [Custom Actions]          │
└───────────────────────────────────────────┘
```

**Player Actions:**
- **Implement All:** MES schedules calibration, training, adjusts tool policy
- **Custom:** Player selects specific actions
- **Ignore:** Problem persists, scrap rate remains high

**SPC (Statistical Process Control):**

MES tracks critical dimensions over time:

```
CNC_02 Bore Diameter Trend (Last 100 Parts):

Parts 1-20:   85.01 mm (within spec ±0.05) ✓ Stable
Parts 21-40:  85.02 mm (trending upward)   ⚠ Warning
Parts 41-60:  85.03 mm (approaching limit)  ⚠ Warning
Parts 61-80:  85.04 mm (near upper limit)   ⚠⚠ Alert
Part 81:      85.08 mm (OUT OF SPEC)        ✗ FAIL

MES Predictive Alert (triggered at Part 40):
"Bore diameter trending toward upper limit (+0.03 mm drift over 40 parts)
 Root Cause Hypothesis: Thermal expansion (coolant temp rising)
 Suggested Action: Increase coolant flow 15% OR reduce spindle speed 5%"

Player Response:
A. Accept MES suggestion → Parts 41-100 stay in spec (0.5% scrap avoided)
B. Ignore → Part 81+ scrapped, potential rework for Parts 61-80
```

**Educational Value:** Teaches players **predictive quality control** - intervening before failures occur is cheaper than reacting after.

---

### 3.3.8 Process Management

**Function:** Monitor processes in real-time, adjust parameters adaptively

**Adaptive Process Control:**

MES monitors sensor data and auto-adjusts parameters to maintain quality:

```
Example: CNC Cutting Force Control

Target Cutting Force: 500 N ± 10%

MES Sensor Monitoring:
Time 0:00  Force: 505 N (1% over)  → Normal variance
Time 0:15  Force: 530 N (6% over)  → Log elevated force
Time 0:30  Force: 580 N (16% over) → WARNING threshold

MES Analysis:
- Tool wear: 68% (from cycle counter)
- Material lot: Same as previous 20 parts (not material issue)
- Hypothesis: Tool dulling → increased resistance

MES Auto-Adjustment (if enabled):
Action: Reduce feed rate 250 → 225 mm/min (10% reduction)
Result: Force drops to 520 N (4% over target - acceptable)
Trade-off: Cycle time +10% (11 min → 12.1 min)
Alert: "CNC_02: Adaptive feed reduction - tool replacement recommended"

Player Visibility:
Notification: "⚠ CNC_02 compensating for tool wear"
Override Option: Player can restore original feed rate (not recommended)
```

**Multi-Variable Control:**

Advanced MES (Tier 3+) can manage multiple parameters simultaneously:

```
Optimize for: Minimize Cycle Time + Maintain Quality

Variables MES Controls:
- Spindle speed (RPM)
- Feed rate (mm/min)
- Cut depth (mm)
- Coolant flow (L/min)

Constraints:
- Surface finish: Ra < 1.6 μm
- Cutting force: < 600 N
- Tool life: > 400 cycles
- Power consumption: < 8 kW

MES Solution (gradient descent algorithm):
Spindle: 2500 RPM → 2650 RPM (+6%)
Feed: 250 → 265 mm/min (+6%)
Cut Depth: 0.5 → 0.45 mm (-10%)
Coolant: 10 → 12 L/min (+20%)

Result:
Cycle Time: 12 min → 11.2 min (-6.7% improvement)
Surface Finish: Ra 1.4 μm (within spec)
Tool Life: 420 cycles projected (meets constraint)
```

---

### 3.3.9 Maintenance Management

**Function:** Schedule preventive maintenance, predict failures

**Preventive Maintenance (PM) Scheduling:**

MES tracks machine usage and schedules maintenance automatically:

```
CNC_01 Maintenance Schedule:

Based on Cycle Counter:
- Spindle bearing: Every 5,000 cycles (Next: 237 cycles)
- Tool changer: Every 2,000 cycles (Next: 1,843 cycles)
- Coolant filter: Every 1,000 cycles (Next: 127 cycles)

Based on Calendar:
- Full inspection: Quarterly (Next: 18 days)
- Lubrication: Monthly (Next: 5 days)

MES Recommendation:
"Schedule coolant filter change during next weekend shutdown"
"Combine with lubrication service for efficiency"

Player Actions:
[Schedule PM] [Postpone (risk downtime)] [View History]
```

**Predictive Maintenance (PdM):**

MES analyzes sensor trends to predict failures before they occur:

```
CNC_01 Vibration Trend Analysis:

Week 1: 2.5 mm/s (baseline)
Week 2: 2.7 mm/s (+8% from baseline)
Week 3: 3.1 mm/s (+24%)
Week 4: 3.8 mm/s (+52%) → ⚠⚠ ALERT

MES Prediction Model:
Historical Data: Vibration >4.0 mm/s → spindle bearing failure within 48h (85% confidence)
Current Trend: +0.5 mm/s per week
Estimated Time to Failure: 10-14 days

┌─ PREDICTIVE MAINTENANCE ALERT ────────────┐
│                                           │
│ Machine: CNC_01                           │
│ Component: Spindle Bearing                │
│ Failure Probability: 85% within 2 weeks   │
│                                           │
│ Recommended Action:                       │
│ Schedule bearing replacement ASAP         │
│                                           │
│ Cost Comparison:                          │
│ Proactive Replacement:                    │
│  - Parts: $1,200                         │
│  - Labor: 2 hours downtime              │
│  - Total: $1,400                         │
│                                           │
│ Reactive Replacement (if failure occurs): │
│  - Emergency Parts: $2,000 (expedited)   │
│  - Labor: 8 hours downtime (production halt)│
│  - Lost Production: ~$3,500              │
│  - Total: $5,500                         │
│                                           │
│ Savings: $4,100 (74% reduction)          │
│                                           │
│ [Schedule Maintenance] [Monitor] [Ignore] │
└───────────────────────────────────────────┘
```

**Player Decision:**
- **Schedule:** Safe, minimal disruption, teaches proactive mindset
- **Monitor:** Gamble that trend stabilizes (risky)
- **Ignore:** High probability of catastrophic failure mid-production

**Educational Value:** Demonstrates **cost-benefit of predictive vs reactive maintenance** - a core lean manufacturing principle.

---

### 3.3.10 Product Tracking and Genealogy

**Function:** Full traceability from raw material to finished product

**Serial Number Tracking:**

Every part receives a unique identifier (auto-generated or scanned):

```
Serial Number Format: [ProductCode]-[Version]-[YearWeek]-[SequenceID]
Example: ENG-v2-2551-S00523

Breakdown:
- ENG: Engine Block
- v2: Version 2
- 2551: Year 2025, Week 51
- S00523: Sequential number (523rd part this week)
```

**Complete Genealogy Record:**

```
┌─ PART GENEALOGY: ENG-v2-S00523 ───────────┐
│                                           │
│ Product: Engine Block v2                  │
│ Current Status: In Assembly               │
│ Current Location: Assembly_Station_03     │
│                                           │
│ ═══════════════════════════════════════   │
│ STAGE 1: Raw Material                     │
│ ═══════════════════════════════════════   │
│ Material: Aluminum 6061-T6                │
│ Lot Number: AL-6061-LOT-4523              │
│ Supplier: Alcoa Corp.                     │
│ Received: 2025-12-15 08:45:12             │
│ Cert: AL-QC-4523-001 (PASS)               │
│                                           │
│ ═══════════════════════════════════════   │
│ STAGE 2: CNC Machining (Roughing)         │
│ ═══════════════════════════════════════   │
│ Machine: CNC_02                           │
│ Operator: Jane_W042 (Skill: 85)          │
│ NC Program: PROG_ENG_BLK_V2_ROUGH.nc      │
│ Start: 2025-12-20 08:15:32                │
│ End: 2025-12-20 08:27:18                  │
│ Cycle: 11.77 min (Target: 12 min) ✓      │
│ Spindle: 2500 RPM (Avg: 2487 RPM)         │
│ Feed: 250 mm/min                          │
│ Tool: EM-12-0042 (Wear: 58%)              │
│ QC: Dimensions within rough tolerance ✓   │
│                                           │
│ ═══════════════════════════════════════   │
│ STAGE 3: CNC Machining (Finishing)        │
│ ═══════════════════════════════════════   │
│ Machine: CNC_02                           │
│ Operator: Jane_W042 (Skill: 85)          │
│ NC Program: PROG_ENG_BLK_V2_FINISH.nc     │
│ Start: 2025-12-20 08:30:05                │
│ End: 2025-12-20 08:47:23                  │
│ Cycle: 17.3 min                           │
│ Tool: EM-06-0089 (Wear: 34%)              │
│ Measured Dimensions:                      │
│   Length: 200.02mm (200.00±0.05) ✓       │
│   Width: 150.01mm (150.00±0.05) ✓        │
│   Height: 180.00mm (180.00±0.05) ✓       │
│   Bore: 85.02mm (85.00±0.05) ✓           │
│ Surface Finish: Ra 1.2μm (<2.0μm) ✓      │
│ QC Result: PASS                           │
│                                           │
│ ═══════════════════════════════════════   │
│ STAGE 4: Assembly (Cylinder Head) [CURRENT]│
│ ═══════════════════════════════════════   │
│ Station: Assembly_03                      │
│ Operator: Carlos_W018 (Skill: 78)        │
│ Start: 2025-12-20 09:05:11                │
│ Tool: Atlas Nutrunner #2                  │
│ Torque Target: 85 Nm ± 1 Nm               │
│ Progress:                                 │
│   Bolt A1: 85.2 Nm, 59° ✓                │
│   Bolt A2: 84.8 Nm, 60° ✓                │
│   Bolt A3: 85.1 Nm, 61° ✓                │
│   Bolt A4: [In Progress...]               │
│                                           │
│ [Export Report] [Print Label] [Audit Log] │
└───────────────────────────────────────────┘
```

**Traceability Use Cases:**

**1. Customer Audit:**
```
Customer Request: "Prove Engine Serial ENG-v2-S00523 was assembled to spec"
MES Response: 
- Generate full genealogy report (PDF)
- Includes all measurements, operator IDs, NC programs used
- Certificates for raw material included
- Digital signatures from QC inspections
Result: Customer satisfied, contract compliance verified
```

**2. Recall Management:**
```
Event: Supplier Alert - "Aluminum Lot AL-6061-LOT-4523 has porosity defects"

MES Query: 
SELECT parts 
WHERE materialLot = "AL-6061-LOT-4523" 
  AND status IN ("InProduction", "Finished", "Shipped")

Results:
- 23 parts in production → HALT immediately, scrap
- 47 parts in finished goods → QUARANTINE, re-inspect
- 12 parts shipped to customers → RECALL (notify customers)

Financial Impact:
- Scrap cost: 23 × $200 = $4,600
- Re-inspection: 47 × $50 = $2,350
- Recall logistics: 12 × $500 = $6,000
- Total: $12,950 + reputation damage

MES Value: Without genealogy, player couldn't identify affected parts
Risk: Shipping defective products → warranty claims, safety liability
```

**3. Quality Investigation:**
```
Problem: 5 engines failed at customer site (same failure mode)

MES Root Cause Analysis:
Common Factors:
- All 5 used Material Lot AL-6061-LOT-4522 ✓
- All 5 machined by CNC_02 ✓
- All 5 assembled by Worker_Bob ✗ (different workers)
- All 5 used Tool EM-12-0041 ✓ ← Smoking gun!

Hypothesis: Tool EM-12-0041 defective (chipped cutting edge)

Verification:
- Inspect tool → confirms chip at edge
- Review other parts using same tool → 8 more suspect parts identified
- Quarantine all affected parts

Corrective Action:
- Replace tool immediately
- Inspect all remaining inventory using that tool
- Update tool inspection procedure (more frequent visual checks)

Prevention:
- MES now flags any tool producing >3% dimensional variance
- Automated tool wear monitoring enhanced
```

**4. Continuous Improvement:**
```
Question: "Why is Worker_Jane 12% more efficient than Worker_Bob?"

MES Comparative Analysis:
Jane's Parts (Last 100):
- Avg Cycle Time: 11.2 min (vs 12 target)
- Scrap Rate: 2.1%
- Setup Time: 18 min avg

Bob's Parts (Last 100):
- Avg Cycle Time: 12.8 min (vs 12 target)
- Scrap Rate: 5.3%
- Setup Time: 24 min avg

Key Differences (from genealogy notes):
- Jane pre-positions tools during coolant fill (saves 2 min setup)
- Jane uses higher spindle speeds within safe limits (reduces cycle time 8%)
- Jane performs mid-cycle visual checks (catches errors early)

Action: Create training video featuring Jane's techniques, train Bob
Result: Bob's performance improves 9% over next month
```

---

### 3.3.11 Performance Analysis

**Function:** Calculate KPIs (OEE, throughput, costs), provide insights

**OEE (Overall Equipment Effectiveness) Calculation:**

MES calculates OEE in real-time for each machine and line:

```
┌─ OEE DASHBOARD: CNC_02 (Shift Summary) ───┐
│                                           │
│ Shift: Morning (8 hours / 480 minutes)   │
│                                           │
│ ═══════════════════════════════════════   │
│ AVAILABILITY: 90.1%                       │
│ ═══════════════════════════════════════   │
│ Planned Production Time: 435 min         │
│   (480 min - 30 breaks - 15 changeover)  │
│                                           │
│ Downtime Breakdown:                       │
│   Setup (new work order): 25 min         │
│   Material delay: 10 min                 │
│   Tool change (unplanned): 8 min         │
│ Operating Time: 392 min                   │
│                                           │
│ Availability = 392/435 = 90.1%            │
│ Target: 95% → ⚠ 4.9 points below         │
│                                           │
│ ═══════════════════════════════════════   │
│ PERFORMANCE: 90.6%                        │
│ ═══════════════════════════════════════   │
│ Theoretical Output:                       │
│   392 min / 12 min per part = 32.67 parts│
│ Actual Output: 29 parts                   │
│                                           │
│ Performance = 29/32.67 = 90.6%            │
│ Target: 95% → ⚠ 4.4 points below         │
│                                           │
│ Speed Loss Analysis:                      │
│   Parts 1-15: 11.8 min avg (good)        │
│   Parts 16-29: 12.4 min avg (slower)     │
│ Hypothesis: Tool wear increased cycle time│
│                                           │
│ ═══════════════════════════════════════   │
│ QUALITY: 96.6%                            │
│ ═══════════════════════════════════════   │
│ Parts Produced: 29                        │
│ Parts Passed QC: 28                       │
│ Parts Scrapped: 1                         │
│                                           │
│ Quality = 28/29 = 96.6%                   │
│ Target: 99% → ⚠ 2.4 points below         │
│                                           │
│ Defect: Part 23 - Bore diameter 85.07mm  │
│ Root Cause: Tool wear >80%                │
│                                           │
│ ═══════════════════════════════════════   │
│ OVERALL OEE: 78.8%                        │
│ ═══════════════════════════════════════   │
│ OEE = 0.901 × 0.906 × 0.966 = 78.8%      │
│                                           │
│ World-Class: >85%                         │
│ Industry Avg: 60-75%                      │
│ This Shift: 78.8% (GOOD, improvable)     │
│                                           │
│ ═══════════════════════════════════════   │
│ MES RECOMMENDATIONS:                      │
│ ═══════════════════════════════════════   │
│ 1. Reduce setup time 25→15 min (SMED)    │
│    Impact: +2.3% Availability = 81.1% OEE│
│                                           │
│ 2. Replace tools at 70% wear (proactive)  │
│    Impact: +3.4% Performance = 82.2% OEE │
│                                           │
│ 3. Implement tool wear compensation       │
│    Impact: +2.4% Quality = 83.8% OEE     │
│                                           │
│ Combined Potential OEE: 87.6% (world-class)│
│                                           │
│ [Implement All] [Customize] [View Trends] │
└───────────────────────────────────────────┘
```

**Throughput Analysis:**
```
Line Throughput (Last 7 Days):

Day 1: 58 parts (Target: 60) → 96.7% ⚠
Day 2: 62 parts              → 103.3% ✓
Day 3: 45 parts (breakdown)  → 75.0% ✗
Day 4: 61 parts              → 101.7% ✓
Day 5: 59 parts              → 98.3% ⚠
Day 6: 63 parts              → 105.0% ✓
Day 7: 60 parts              → 100.0% ✓

Weekly Average: 58.3 parts/day (Target: 60)
Consistency: High variance (Day 3 outlier)

MES Insight:
"Day 3 breakdown caused by tool EM-12-0042 failure"
"Implementing predictive maintenance could prevent similar events"
"Estimated annual savings: 3 breakdowns avoided = $15,000"
```

**Cost Per Unit Analysis:**
```
Cost Breakdown (Engine Block v2):

Direct Materials:
  Aluminum billet: $52.00
  Bolts (set of 20): $8.00
  Coolant/consumables: $3.50
  Subtotal: $63.50

Direct Labor:
  CNC Machining: 29.77 min @ $48/hr = $23.82
  Assembly: 15 min @ $36/hr = $9.00
  QC: 5 min @ $42/hr = $3.50
  Subtotal: $36.32

Overhead:
  Machine depreciation: $8.20
  Energy (9.3 kWh @ $0.12): $1.12
  Factory overhead allocation: $14.80
  Subtotal: $24.12

Scrap Allocation (2.8% rate):
  $63.50 × 0.028 = $1.78

TOTAL COST PER UNIT: $125.72

Contract Selling Price: $180.00
Gross Margin: $54.28 (30.2%)

MES Optimization Opportunity:
"Reducing scrap to 1.5% saves $0.83/unit"
"On 500-unit contract, savings = $415"
```

---

## 3.4 MES Scripting System (Player-Facing)

### 3.4.1 Tiered Complexity (Progressive Depth)

The MES scripting system has **5 tiers** that unlock progressively:

**Tier 0: No MES (Tutorial)**
- Machines run with hard-coded defaults
- Player manually clicks "Start" on each machine
- No automation
- **Efficiency:** ~70% of potential

**Tier 1: GUI Presets (Casual - Unlock Level 1)**
- Dropdown menus with pre-configured strategies:
  - "High Speed / Low Precision" (for non-critical parts)
  - "Balanced" (default)
  - "High Precision / Low Speed" (for critical parts)
- MES applies preset parameters automatically
- **Efficiency:** ~85% of potential
- **Player Time Investment:** 5 minutes to configure

**Tier 2: Block-Based Editor (Strategic - Unlock Level 6)**
- Visual programming interface (like Scratch/Blockly)
- Drag-and-drop IF-THEN-ELSE logic blocks
- No coding knowledge required
- **Efficiency:** ~95% of potential
- **Player Time Investment:** 30-60 minutes to learn, 15 min per rule
- **Example:**
  ```
  [WHEN] Part arrives at Nutrunner
  [IF] Part.version == "v2"
  [THEN] Set Nutrunner.torque = 95
  [ELSE] Set Nutrunner.torque = 85
  [END]
  ```

**Tier 3: Text-Based Scripting (Expert - Unlock Level 12)**
- Lua-like pseudocode
- Full access to machine states, sensor data, historical trends
- Can create complex multi-condition logic
- **Efficiency:** 100-110% of potential (exceeds baseline through optimization)
- **Player Time Investment:** 2-3 hours to master, 30 min per complex rule
- **Example:**
  ```lua
  function onPartArrive(part)
    -- Dynamic torque based on version and tool condition
    if part.version >= 2 then
      local tool = getCurrentTool()
      if tool.wear > 0.7 then
        scheduleMaintenance("Tool replacement needed")
        -- Compensate for wear
        machine.feedRate = machine.feedRate * 0.9
      end
      applyTorqueProfile("precision_v2")
    else
      applyTorqueProfile("standard")
    end
    
    -- Adaptive quality sampling
    local recentScrap = getScrapRate(lastNParts=20)
    if recentScrap > 0.05 then
      machine.qcSampleRate = 0.20  -- Increase to 20%
      logAlert("Elevated scrap detected - QC rate increased")
    else
      machine.qcSampleRate = 0.05  -- Standard 5%
    end
  end
  ```

**Tier 4: Advanced Automation (Late-Game - Unlock Level 18)**
- Predictive analytics integration
- Multi-line coordination
- Auto-scheduling and dynamic rerouting
- **Efficiency:** 110-120% (significant competitive advantage)
- **Example:** MES predicts bottleneck 30 minutes before it occurs, pre-emptively reroutes parts via AGVs

**Tier 5: AI-Assisted MES (Endgame - Unlock Level 24)**
- Machine learning algorithms suggest optimizations
- Digital twin integration for "what-if" analysis
- Self-optimizing factory (player reviews/approves changes)
- **Efficiency:** 115-125%
- **Example:** AI discovers non-obvious pattern: "Parts machined on CNC_02 between 2-4pm have 8% higher scrap due to afternoon sun heating the east wall - suggest scheduling precision parts in morning"

---

### 3.4.2 MES Block Editor (Tier 2 Detailed Design)

**UI Layout:**
```
┌──────────────────────────────────────────────────────────────┐
│ MES RULE EDITOR - Assembly_Station_03       [Test] [Deploy]  │
├────────────┬─────────────────────────────────────────────────┤
│ BLOCKS     │ WORKSPACE                                       │
│            │                                                 │
│ Triggers:  │ [START: When Part Arrives]                     │
│ • Part     │   ↓                                            │
│ • Machine  │ [IF] [Part.version] [>=] [2]                   │
│ • QC       │   ↓ TRUE Branch                                │
│ • Time     │   ├─ [SET] [Nutrunner.torque] = [95]          │
│            │   ├─ [SET] [Nutrunner.tolerance] = [1]        │
│ Conditions:│   ├─ [SET] [QC.sampleRate] = [0.10]           │
│ • Compare  │   └─ [LOG] "High-precision part detected"     │
│ • Logic    │   ↓                                            │
│ • Math     │ [ELSE]                                         │
│            │   ↓ FALSE Branch                               │
│ Actions:   │   ├─ [SET] [Nutrunner.torque] = [85]          │
│ • Set Param│   ├─ [SET] [Nutrunner.tolerance] = [3]        │
│ • Route    │   └─ [SET] [QC.sampleRate] = [0.05]           │
│ • Alert    │   ↓                                            │
│ • Schedule │ [SEND TO] [Next Station: QC_01]                │
│            │                                                 │
│ Data:      │ ┌─ SIMULATION PREVIEW ─────────────────┐       │
│ • Part     │ │ Tested on: Last 100 parts            │       │
│ • Machine  │ │ v1 parts: 60 → Torque 85 (correct) ✓ │       │
│ • Worker   │ │ v2 parts: 40 → Torque 95 (correct) ✓ │       │
│ • Buffer   │ │                                       │       │
│            │ │ Efficiency Gain: +12%                │       │
│ Math:      │ │ Scrap Reduction: -8%                 │       │
│ • Add/Sub  │ │ Estimated Value: $585 per 100 parts  │       │
│ • Multiply │ └───────────────────────────────────────┘       │
│ • Average  │                                                 │
│            │                                                 │
│ [Examples] │ [Help: Video Tutorials] [Community Library]    │
└────────────┴─────────────────────────────────────────────────┘
```

**Block Categories (Detailed):**

**1. Triggers (When to run this rule):**
- `[When Part Arrives]` at specific station
- `[When Machine State Changes]` (Idle→Running, Running→Error, etc.)
- `[When QC Detects Defect]`
- `[When Buffer Level]` reaches threshold
- `[Every X Cycles]`
- `[On Schedule]` (time-based: every hour, daily at 6am, etc.)

**2. Conditions (IF statements):**
- **Part Properties:**
  - `Part.version`, `Part.material`, `Part.customer`, `Part.size`
- **Machine State:**
  - `Machine.status`, `Machine.toolWear`, `Machine.cycleCount`, `Machine.temperature`
- **QC Data:**
  - `getScrapRate(last=N)`, `getTrendDirection()`, `getDefectType()`
- **Worker:**
  - `Worker.skill`, `Worker.fatigue`, `Worker.specialty`
- **Inventory:**
  - `Material.stockLevel`, `Buffer.occupancy`, `Buffer.avgWaitTime`
- **Time:**
  - `currentShift`, `dayOfWeek`, `hoursUntilDeadline`

**3. Actions (THEN do this):**
- **Set Parameters:**
  - `Set Machine.torque`, `Set Machine.speed`, `Set Machine.feedRate`
  - `Set QC.sampleRate`, `Set Conveyor.speed`
- **Routing:**
  - `Send Part To [Station]`
  - `Route Via [Path A/B]` (for multi-path layouts)
- **Alerts:**
  - `Alert Player ["message"]`
  - `Log Event ["message"]`
- **Scheduling:**
  - `Schedule Maintenance [Machine] [When]`
  - `Pause Production`
  - `Adjust Worker Assignment`

**4. Math & Logic:**
- Arithmetic: `+`, `-`, `*`, `/`, `%` (modulo)
- Comparison: `==`, `!=`, `<`, `>`, `<=`, `>=`
- Boolean: `AND`, `OR`, `NOT`
- Functions: `AVG(list)`, `MAX(list)`, `MIN(list)`, `TREND(data, window)`

**5. Variables (Store custom data):**
- Create variable: `defectCount`, `lastMaintenanceDate`, `consecutivePasses`
- Increment: `defectCount = defectCount + 1`
- Use in conditions: `IF defectCount > 5 THEN...`

---

### 3.4.3 MES Simulation Mode

**Purpose:** Test MES rules risk-free before deploying to live production

**How It Works:**
1. Player creates/edits a rule in the MES editor
2. Clicks **[Test]** button
3. Game runs a virtual simulation:
   - Uses historical data from last N production runs
   - Applies player's MES rule
   - Compares results to baseline (no rule) and current production
4. Displays comprehensive results report
5. Player can tweak and re-test unlimited times (no cost)

**Simulation Report Example:**
```
┌─ MES SIMULATION RESULTS ──────────────────────────────────────┐
│                                                               │
│ Rule Name: "V2 Precision Torque Adjustment"                  │
│ Tested On: Last 100 parts (Historical Data)                  │
│ Part Mix: 60× v1, 40× v2                                     │
│                                                               │
│ ═════════════════════════════════════════════════════════════ │
│ BASELINE (No Rule):                                           │
│ ═════════════════════════════════════════════════════════════ │
│ Avg Cycle Time: 12.5 min/part                                │
│ Throughput: 4.8 parts/hour                                    │
│ Scrap Rate: 6.2% overall                                      │
│   ├─ v1: 3.0% (expected)                                      │
│   └─ v2: 11.0% (HIGH - using wrong torque)                    │
│ OEE: 72.3%                                                    │
│ Cost/Part: $128.50 (includes scrap allocation)               │
│                                                               │
│ ═════════════════════════════════════════════════════════════ │
│ WITH YOUR RULE:                                               │
│ ═════════════════════════════════════════════════════════════ │
│ Avg Cycle Time: 12.3 min/part (2% faster) ✓                 │
│ Throughput: 4.9 parts/hour (+2%) ✓                           │
│ Scrap Rate: 3.8% overall (-39% improvement!) ✓✓              │
│   ├─ v1: 3.0% (unchanged)                                     │
│   └─ v2: 5.0% (IMPROVED from 11% - correct torque applied)   │
│ OEE: 79.1% (+6.8 points) ✓✓                                  │
│ Cost/Part: $123.20 (-4.1% reduction) ✓                       │
│                                                               │
│ ═════════════════════════════════════════════════════════════ │
│ FINANCIAL IMPACT:                                             │
│ ═════════════════════════════════════════════════════════════ │
│ Scrap Cost Savings:                                           │
│   Scrap reduced: 6.2% → 3.8% = 2.4 parts per 100             │
│   Value: 2.4 × $150 material = $360 per 100 parts            │
│                                                               │
│ Cycle Time Savings:                                           │
│   Time saved: 0.2 min/part × 100 = 20 minutes                │
│   = ~1.6 additional parts worth $288                          │
│                                                               │
│ Annual Projection (assuming 12,000 parts/year):               │
│   Scrap savings: $43,200                                      │
│   Throughput gain: $34,560                                    │
│   TOTAL ANNUAL VALUE: $77,760                                 │
│                                                               │
│ ═════════════════════════════════════════════════════════════ │
│ RISK ASSESSMENT:                                              │
│ ═════════════════════════════════════════════════════════════ │
│ ✓ No negative side effects detected                          │
│ ✓ Rule logic validated (no syntax errors)                    │
│ ✓ Performance impact minimal (+2% cycle time acceptable)     │
│ ⚠ Recommendation: Monitor first 50 parts after deployment    │
│                                                               │
│ Risk Level: LOW (safe to deploy)                             │
│                                                               │
│ ═════════════════════════════════════════════════════════════ │
│                                                               │
│ [← Back to Editor] [Deploy to Production] [Save for Later]   │
│                                                               │
└───────────────────────────────────────────────────────────────┘
```

**Player Decision Tree:**
- **Deploy:** Rule goes live, starts affecting real production
- **Back to Editor:** Tweak parameters (e.g., try torque = 93 instead of 95)
- **Save for Later:** Keep rule in library, deploy when ready

**Educational Value:**
- Teaches **data-driven decision making** (not guessing)
- Shows **opportunity cost** of NOT optimizing
- Demonstrates **low-risk experimentation** mindset

---

## 3.5 Multi-Product / Mixed-Model Production

### 3.5.1 The Challenge

**Scenario:** Player has 3 engine variants they need to produce on the same production line:

- **Engine v1 (Basic):** 200 units/week
- **Engine v2 (Standard):** 150 units/week  
- **Engine v3 (Premium):** 50 units/week

**Without MES (Traditional Batch Production):**
```
Week Schedule:
Monday-Tuesday:     Produce 200× v1 (2 days)
Wednesday-Thursday: Produce 150× v2 (2 days)
Friday:             Produce 50× v3 (1 day)

Changeover Times:
v1 → v2: 45 minutes (change tools, adjust parameters, retrain workers)
v2 → v3: 60 minutes (more complex setup)

Problems:
1. Large batches = high WIP inventory ($40k tied up in storage)
2. Long changeovers = 105 min/week lost (2.2% capacity)
3. Worker confusion = 12% error rate during first units after changeover
4. If v2 demand spikes, can't respond until Thursday
```

**With MES (Mixed-Model Production):**
```
Sequence: v1, v1, v2, v1, v2, v3, v1, v1, v2... (repeating pattern)

Changeover Time: <5 seconds (RFID read + MES auto-config)

Benefits:
1. Low WIP = $3k inventory (87% reduction)
2. Zero changeover waste (absorbed into conveyor transit time)
3. Zero worker errors (MES displays correct specs automatically)
4. Demand spikes handled immediately (flexible sequence)

Result: 18% higher throughput, 92% lower inventory costs
```

---

### 3.5.2 MES-Enabled Mixed-Model Implementation

**Part Identification (RFID/Barcode):**

Each part carrier has an RFID tag:
```
Tag Data:
- PartID: "ENG-v2-S00087"
- ProductType: "v2"
- CustomerOrder: "Contract_CO2025-42"
- Priority: "Normal"
- SpecialInstructions: "Expedite QC"
```

**MES Station-by-Station Configuration:**

**Station 1: CNC Machining**
```
MES Rule (Text-Based Script):

function onPartArrive(partTag)
  product = partTag.productType  -- "v1", "v2", or "v3"
  
  -- Load appropriate NC program and parameters
  if product == "v1" then
    loadNCProgram("PROG_V1.nc")
    setSpindleSpeed(2500)  -- RPM
    setFeedRate(250)       -- mm/min
    setCoolantFlow(10)     -- L/min
    
  elseif product == "v2" then
    loadNCProgram("PROG_V2.nc")
    setSpindleSpeed(2200)  -- Slower for tighter tolerance
    setFeedRate(220)
    setCoolantFlow(12)     -- Higher coolant for precision
    
  elseif product == "v3" then
    loadNCProgram("PROG_V3.nc")
    setSpindleSpeed(2800)  -- v3 is simpler geometry, can go faster
    setFeedRate(280)
    setCoolantFlow(10)
  end
  
  -- Start machining automatically
  startMachining()
  
  -- Update HMI display for operator
  displayPartInfo(product, partTag.customerOrder)
end
```

**Station 2: Assembly (Atlas Nutrunner)**
```
MES Rule:

function onPartArrive(partTag)
  product = partTag.productType
  
  -- Configure nutrunner for each variant
  if product == "v1" then
    nutrunner.setTorque(75, tolerance=3)   -- Nm
    boltSequence = ["A1", "A2", "A3", "A4"]  -- Simple 4-bolt
    
  elseif product == "v2" then
    nutrunner.setTorque(85, tolerance=1.5)
    boltSequence = ["A1", "A4", "A2", "A3"]  -- Cross-pattern
    
  elseif product == "v3" then
    nutrunner.setTorque(95, tolerance=1, angle=60)  -- Torque+angle
    boltSequence = ["A1", "A4", "A2", "A3", "A5", "A6"]  -- 6-bolt
  end
  
  -- Display instructions on HMI
  displayBoltSequence(boltSequence)
  displayTorqueSpec(nutrunner.torque, nutrunner.tolerance)
  
  -- Enforce sequence (MES locks out-of-order bolts)
  enforceSequence(boltSequence)
end
```

**Station 3: Quality Control**
```
MES Rule:

function onPartArrive(partTag)
  product = partTag.productType
  
  -- Load product-specific tolerance specs
  spec = getToleranceSpec(product)
  
  -- Adjust QC sampling rate based on product maturity
  if product == "v1" then
    qcSampleRate = 0.05  -- 5% (mature product)
    
  elseif product == "v2" then
    qcSampleRate = 0.10  -- 10% (newer, needs monitoring)
    
  elseif product == "v3" then
    qcSampleRate = 0.20  -- 20% (premium, highest scrutiny)
    -- v3 also requires functional test
    enableFunctionalTest("PressureTest", min=150, max=200)
  end
  
  -- Perform inspection
  inspectDimensions(spec)
  
  -- If defect detected, reroute to rework buffer
  if defectDetected() then
    routeToRework()
    alertPlayer("QC failure on " .. product .. " - " .. getDefectType())
  end
end
```

---

### 3.5.3 Sequencing Optimization

**Goal:** Minimize total changeover time while balancing workload

**Strategy A: Batching (Old Way)**
```
Schedule:
┌───────┬───────┬───────┬───────┬───────┐
│  v1   │  v1   │  v2   │  v2   │  v3   │
│ 100   │ 100   │  75   │  75   │  50   │
│       │       │       │       │       │
│ ────> │ ────> │ ────> │ ────> │ ────> │
└───────┴───────┴───────┴───────┴───────┘
    ↑       ↑       ↑       ↑
   45min   0min   45min   60min  (changeovers)

Total Changeover: 150 min per 400 parts = 0.375 min/part
Throughput Impact: -3.1%
```

**Strategy B: Mixed-Model (MES Way)**
```
Sequence Pattern: v1, v1, v2, v1, v2, v3, v1, v1, v2, ...
(Repeats to produce 200 v1, 150 v2, 50 v3 over week)

Changeover Time per Part: 5 seconds (RFID read + parameter load)
Effectively ZERO (happens during conveyor transit)

Throughput Impact: 0%
WIP Reduction: 87%

Additional Benefits:
- Flexible to demand changes (can adjust sequence daily)
- Workers never confused (HMI auto-updates)
- Zero chance of using wrong specs
```

**MES Sequencing Logic (Advanced):**
```
MES can optimize sequence to balance workload across stations:

Problem: v3 takes 2× longer at Assembly than v1
Solution: Space out v3 parts to avoid bottleneck

Optimized Sequence:
v1, v1, v1, v2, v1, v1, v3, v1, v2, v1... 
(v3 appears every 6-8 parts, not clumped together)

Result: Assembly station stays balanced, no idle time
```

---

### 3.5.4 Part Proliferation Management

**Problem:** 3 engine variants → 3× component types to manage

**Example:**
- v1 uses M10 bolts
- v2 uses M12 bolts
- v3 uses M14 bolts

**Traditional Approach:**
- Stock all 3 bolt types at assembly station
- Worker must remember which bolt for which engine
- Error rate: 8% (worker grabs wrong bolt occasionally)

**MES Solution: Smart Kanban Bins**

```
┌─ SMART PARTS BIN ─────────────────────┐
│                                       │
│ RFID Reader detects: Engine v2        │
│                                       │
│ Bin Compartments:                     │
│                                       │
│ [Compartment A: M10 Bolts]  🔴 RED    │
│  (Not needed for v2)                  │
│                                       │
│ [Compartment B: M12 Bolts]  🟢 GREEN  │
│  ← PICK THIS ONE                      │
│  Quantity: 28 (low stock warning)     │
│                                       │
│ [Compartment C: M14 Bolts]  🔴 RED    │
│  (Not needed for v2)                  │
│                                       │
│ If wrong compartment opened:          │
│ ⚠ ALERT: "Incorrect part selected!"  │
│ ⚠ Nutrunner will not activate        │
│                                       │
└───────────────────────────────────────┘
```

**Worker Experience:**
1. Part arrives at assembly station
2. RFID reader beeps, reads part tag
3. Green light illuminates on correct bin
4. Worker picks bolts from green-lit compartment
5. Impossible to select wrong part (other bins locked or alarmed)

**Result:**
- Error rate: 0% (physically impossible to grab wrong part)
- Worker cognitive load: Near zero
- Training time: Minimal (visual system is intuitive)

---

## 3.6 Advanced MES Features (Tier 4-5)

### 3.6.1 Predictive Analytics (Tier 4)

**Feature:** MES predicts future problems before they occur

**Example: Bottleneck Prediction**
```
Current State (2:15pm):
- CNC_02 buffer: 42% full (normal)
- Lathe_01 producing at 6 parts/hour
- Assembly running smoothly

MES Prediction (based on historical patterns):
"At current production rates, CNC_02 buffer will reach 100% at 3:45pm (90 min)"

MES Proactive Actions:
1. Alert player 90 min in advance
2. Suggest options:
   A. Slow Lathe_01 to 5 parts/hour (reduces buffer growth)
   B. Speed up CNC_02 by 8% (increases buffer drain)
   C. Activate backup CNC_01 for overflow
   D. Do nothing (accept temporary stoppage at 3:45pm)

Player selects Option B (speed up CNC):
Result: Buffer peaks at 85% at 3:30pm, then drains. No stoppage occurs.
Value: Avoided 25-minute production halt ($350 lost opportunity prevented)
```

---

### 3.6.2 Digital Twin Integration (Tier 4-5)

**Feature:** Virtual replica of factory for risk-free "what-if" analysis

**Player Use Cases:**

**Scenario 1: "Should I buy a 2nd CNC?"**
```
Player Question: "Current CNC_02 is bottleneck. Should I buy CNC_01 for $35k?"

Digital Twin Simulation:
- Input: Current factory state + hypothetical CNC_01
- Run: Simulate 1 month of production with current contract mix
- Output: 
  - Throughput increase: +32% (from 58 to 77 parts/day)
  - Bottleneck shifts to Assembly (new constraint)
  - ROI: 8.2 months payback period
  
MES Recommendation:
"Yes, CNC_01 purchase justified IF contracts sustain current volume.
Alternative: Optimize existing CNC_02 with better MES rules (+12% throughput)
 for free - try this first, buy CNC_01 if still constrained"
```

**Scenario 2: "What if contract volume doubles?"**
```
Player Question: "Customer wants to double order size. Can I handle it?"

Digital Twin Simulation:
- Input: 2× current volume
- Output:
  - Current capacity: 400 parts/week
  - Demand with 2× order: 800 parts/week
  - Shortfall: 400 parts/week (50% capacity gap)
  
Bottleneck Analysis:
  - CNC: 120% overloaded
  - Assembly: 95% (near limit)
  - QC: 70% (has capacity)
  
Investment Required:
  - Option A: Buy 2nd CNC ($35k) + hire 2 workers ($7k/mo) = 760 parts/week (95% of need)
  - Option B: Add 2nd shift ($15k/mo labor) + 2nd CNC ($35k) = 880 parts/week (110% of need) ✓
  
MES Recommendation: "Option B - 2nd shift + 2nd CNC meets demand with 10% buffer"
```

---

### 3.6.3 AI-Assisted Optimization (Tier 5)

**Feature:** Machine learning analyzes patterns and suggests improvements

**Example 1: Anomaly Detection**
```
AI Analysis:
"Parts machined on CNC_02 between 2-4pm have 8% higher scrap rate"

Data Correlation:
- Time of day: 2-4pm (consistent pattern over 30 days)
- Environmental: Factory east wall faces afternoon sun
- Temperature: Coolant temp rises 3°C during this window
- Hypothesis: Thermal expansion causing dimensional drift

AI Recommendation:
"Increase coolant flow 20% from 1:45-4:15pm"
Predicted Impact: Scrap rate 8% → 3% during affected window
Annual Savings: $12,400

Player Action: Enable AI recommendation → Problem solved
```

**Example 2: Non-Obvious Optimization**
```
AI Discovery:
"Worker_Jane's parts have 12% lower scrap when she works morning shift vs afternoon shift"

Correlation Analysis:
- Not fatigue (Jane's afternoon fatigue is low)
- Not skill (same worker)
- Root cause: Jane pre-stages tools during morning coffee break
             (has 10 extra minutes in morning routine)
             
AI Insight: "Tool pre-staging reduces setup errors"

AI Recommendation:
"Add 10-minute 'setup prep' to all shift starts"
Predicted Impact: -9% scrap rate across all workers
Cost: $0 (time reallocation)

Player Action: Accept → Scrap rate improves 9% factory-wide
Educational Value: Teaches "work smarter, not harder" + systems thinking
```

---

## 3.7 MES Integration with Other Systems

### 3.7.1 MES ↔ ERP Integration

**ERP (Level 4) sends to MES (Level 3):**
- Work orders (what to produce, how many, by when)
- Material availability (can production start?)
- Cost targets (budget constraints)

**MES sends back to ERP:**
- Production actuals (units completed)
- Material consumption (inventory updates)
- Labor hours (cost tracking)
- Scrap/waste (loss accounting)

**Example Flow:**
```
1. Player accepts contract in ERP: "500 Engine v2, deliver in 2 weeks"
2. ERP generates work order WO-2025-123, sends to MES
3. MES checks resources:
   ✓ Material: 520 aluminum billets available
   ✓ Capacity: 60 parts/day × 10 days = 600 potential (sufficient)
   ✗ Constraint: Tool inventory low (only 2 end mills, need 4)
4. MES alerts ERP: "Material constraint - order 2 end mills ($1,200)"
5. ERP auto-purchases (if player approved auto-procurement)
6. MES schedules production to start when tools arrive (3 days)
7. Production runs, MES reports daily to ERP:
   - Day 1: 58 parts complete, 2 scrapped
   - Day 2: 61 parts complete, 1 scrapped
   - ...
8. MES final report to ERP:
   - Total produced: 502 (500 good + 2 buffer)
   - Material used: 504 billets
   - Labor: 247 hours
   - Scrap: 4 parts ($600 loss)
9. ERP calculates contract profitability:
   - Revenue: $90,000
   - Costs: $62,340
   - Profit: $27,660 (30.7% margin)
```

---

### 3.7.2 MES ↔ PLM Integration

**PLM (Product Lifecycle) sends to MES:**
- Part definitions (BOMs, drawings, specs)
- Process routings (sequence of operations)
- Quality requirements (tolerances, inspection criteria)
- ECOs (engineering changes)

**MES sends back to PLM:**
- "As-built" records (how part was actually made)
- Quality data (actual measurements vs. specs)
- Process feedback (cycle times, yield rates)

**ECO Example (from Section 3.3.4 Document Control):**
```
PLM triggers ECO: "Crankshaft v1 → v2"
↓
MES receives ECO, performs:
1. Archive old NC programs / work instructions
2. Load new programs / instructions
3. Update torque settings in MES rules
4. Flag workers for retraining
5. Adjust QC inspection criteria
↓
MES confirms to PLM: "ECO implemented, production ready for v2"
```

---

### 3.7.3 MES ↔ Quality Systems

**MES sends to QC:**
- Which parts to inspect (sampling strategy)
- Inspection criteria (tolerances for each feature)
- Part genealogy (for traceability)

**QC sends back to MES:**
- Inspection results (pass/fail, actual measurements)
- Defect data (type, frequency, suspected root cause)

**Closed-Loop Quality Control:**
```
1. QC detects trend: "Last 5 parts trending toward upper tolerance limit"
2. QC alerts MES
3. MES analyzes:
   - Root cause likely: Tool wear (68%, approaching replacement)
   - Predicted: Next 10 parts will exceed tolerance if no action
4. MES auto-adjusts:
   - Reduce feed rate 8% (compensates for tool wear)
   - Schedule tool replacement after current batch
5. MES informs QC: "Corrective action taken, monitor next 5 parts"
6. QC verifies: Next 5 parts back in center of tolerance
7. MES logs: "Adaptive control prevented 10 scrap parts, saved $1,500"
```

---

## 3.8 MES UI/UX Summary

**Main MES Dashboard:**
```
┌─ MES CONTROL CENTER ──────────────────────────────────────┐
│                                                           │
│ ┌─ Production Status ───┐ ┌─ Active Rules ───┐ ┌─ KPIs ─┐│
│ │ Line 1: 78% OEE       │ │ ✓ v2 Torque Adj │ │ Thru:  ││
│ │ CNC_02, Lathe_01      │ │ ✓ Auto QC Sample│ │ 7.2/hr ││
│ │ v2 (15/50) ETA 2.3h   │ │ ✗ Predictive PM │ │ Scrap: ││
│ │ [Details] [Adjust]    │ │   (locked)      │ │ 2.8%   ││
│ └───────────────────────┘ └─────────────────┘ └────────┘│
│                                                           │
│ ┌─ Alerts ──────────────┐ ┌─ Machine Grid ──────────────┐│
│ │⚠CNC_02 tool wear 75%  │ │[CNC_01: IDLE] [CNC_02: RUN●]││
│ │⚠Buffer A 85% full     │ │[Lathe: SETUP] [Assy: RUN]   ││
│ │✓QC: All pass (2h)     │ │[QC: RUN] [Buffer_A: 85%▲]   ││
│ │ [View All]            │ │                              ││
│ └───────────────────────┘ └──────────────────────────────┘│
│                                                           │
│ [Rule Editor] [Performance Analytics] [Simulation Lab]    │
└───────────────────────────────────────────────────────────┘
```

**Key UX Principles:**
1. **Clarity:** Status always visible (color-coded)
2. **Accessibility:** Casual players see summaries, experts can drill down
3. **Feedback:** Immediate (real-time updates, animations)
4. **Guidance:** MES suggests actions, player decides
5. **Safety:** Simulation mode prevents costly mistakes

---

## 3.9 MES Progression & Unlocks

| Player Level | MES Feature Unlocked | Efficiency Potential |
|--------------|---------------------|---------------------|
| 1-5 (Tutorial) | GUI Presets | 85% |
| 6-8 | Block Editor | 90% |
| 9-11 | Multi-Condition Logic | 95% |
| 12-15 | Text-Based Scripting | 100% |
| 16-18 | Predictive Analytics | 105% |
| 19-21 | Digital Twin | 110% |
| 22-24 | AI-Assisted Optimization | 115% |
| 25 (Endgame) | Full Automation Suite | 120% |

**Key Insight:** Efficiency gap between casual (85%) and expert (120%) creates meaningful **strategic depth** without **punishing casual players** - both can succeed, experts just optimize more.

---

**End of Section 3 - MES System**

---

# 4. PLM SYSTEM & PRODUCT LIFECYCLE MANAGEMENT

## 4.1 PLM Overview & Philosophy

**PLM (Product Lifecycle Management)** manages the complete journey of engine products from concept through production to phase-out. It's the **single source of truth** for what to make, how to make it, and what standards to meet.

**Design Philosophy:**
- **Progressive Complexity:** Early game = simple single-version products, late game = complex multi-version portfolio
- **Integration:** PLM feeds MES (how to make), connects to ERP (materials needed), drives QC (inspection criteria)
- **Real-World Authenticity:** BOMs, process routings, ECOs mirror actual automotive/industrial practices
- **Player Agency:** In-house products = full control, OEM contracts = customer-defined specs

**Core PLM Functions:**
1. **Bill of Materials (BOM)** - What parts make up a product
2. **Process Routing** - Sequence of operations to make each part
3. **Engineering Change Orders (ECOs)** - How products evolve over time
4. **Part Versioning** - Managing multiple variants simultaneously
5. **Product Definition Layer** - Complete metadata for MES/QC integration

---

## 4.2 Product Lifecycle Stages

Every product (engine) goes through defined stages:

```
[Concept/R&D] → [Design] → [Prototype] → [Production] → [Mature] → [Phase-Out] → [Obsolete]
```

### 4.2.1 Stage Details

**Concept/R&D (Weeks 0-4):**
- Engineering team designs product (player allocates R&D resources)
- BOM created, process routing defined
- Material/cost estimates generated
- **Player Actions:** Fund R&D, review designs, approve/reject

**Design (Weeks 4-6):**
- Finalize specifications, tolerances
- Create NC programs, work instructions
- Define quality criteria
- **Player Actions:** Review costs, adjust specs if needed

**Prototype (Weeks 6-8):**
- Produce first units (1-5 parts)
- Test fit/function
- Validate manufacturing process
- **Player Actions:** Troubleshoot issues, refine process

**Production (Weeks 8+):**
- Full-scale manufacturing begins
- MES uses PLM data for all parameters
- Quality data feeds back to PLM
- **Player Actions:** Monitor yields, optimize as needed

**Mature (Ongoing):**
- Stable production, minimal changes
- Lowest scrap rates (workers experienced)
- Highest margins (amortized R&D costs)
- **Player Actions:** Harvest profits, consider next-gen

**Phase-Out (Planned Transition):**
- New version ready, transition begins
- Produce remaining inventory of old version
- Retool machines for new version
- **Player Actions:** Time transition to minimize waste

**Obsolete (Archived):**
- No longer produced
- Documentation retained for warranty/service
- Parts/tooling scrapped or sold
- **Player Actions:** Clear inventory, free up capacity

---

## 4.3 Bill of Materials (BOM) Structure

### 4.3.1 Hierarchical BOM

Products are decomposed into **levels** from assembly down to raw materials:

```
Level 0: Finished Product
└─ Engine Block Assembly v2

Level 1: Major Assemblies
├─ Cylinder Block
├─ Cylinder Head
└─ Hardware Kit

Level 2: Components
├─ Cylinder Block
│  ├─ Cast Block (raw)
│  ├─ Machining (operation)
│  └─ Finishing (operation)
├─ Cylinder Head
│  ├─ Cast Head (raw)
│  ├─ CNC Machining (operation)
│  └─ Valve Seats (insert)
└─ Hardware Kit
   ├─ M12 Bolts (×20)
   ├─ M8 Bolts (×16)
   └─ Gaskets (×2)

Level 3: Raw Materials
├─ Aluminum 6061-T6 Billet (25kg)
├─ Steel Bolts M12 (Grade 10.9)
├─ Steel Bolts M8 (Grade 8.8)
└─ Graphite Gasket Material
```

### 4.3.2 BOM Data Schema

Each BOM entry contains:

```json
{
  "partID": "ENG-BLK-v2-001",
  "name": "Cylinder Block",
  "level": 1,
  "quantity": 1,
  "uom": "each",
  "material": {
    "type": "Aluminum_6061_T6",
    "weight_kg": 12.5,
    "cost_per_kg": 4.20,
    "supplier": "Alcoa_Corp"
  },
  "specifications": {
    "dimensions": {"length": 200, "width": 150, "height": 180, "unit": "mm"},
    "tolerance": 0.05,
    "criticality": "high",
    "surfaceFinish": "Ra_1.6_max"
  },
  "operations": [
    {"opID": "OP-010", "name": "Roughing", "machine": "CNC"},
    {"opID": "OP-020", "name": "Finishing", "machine": "CNC"},
    {"opID": "OP-030", "name": "Deburring", "machine": "Manual"}
  ],
  "routing": "RT-ENG-BLK-v2",
  "traceability": true,
  "version": 2,
  "effectiveDate": "2025-12-01",
  "obsoleteDate": null
}
```

### 4.3.3 BOM Use Cases in Gameplay

**Use Case 1: Material Procurement (ERP Integration)**
```
Player accepts contract: "Produce 100 Engine v2"

PLM calculates material requirements:
- 100× Aluminum billets (25kg each) = 2,500kg
- 100× Hardware kits (20× M12 + 16× M8 + 2× Gaskets)
  = 2,000 M12 bolts, 1,600 M8 bolts, 200 gaskets
- Coolant/consumables (estimated)

ERP checks inventory:
✓ Aluminum: 2,800kg in stock (sufficient)
✗ M12 Bolts: Only 1,200 in stock (need 800 more)
✓ M8 Bolts: 2,000 in stock (sufficient)
✗ Gaskets: Only 120 in stock (need 80 more)

ERP auto-generates purchase orders:
- M12 Bolts: 1,000 units (includes 20% buffer)
- Gaskets: 100 units (includes 20% buffer)
Estimated delivery: 3 days
Cost: $1,850

MES schedules production start for Day 4 (when materials arrive)
```

**Use Case 2: Cost Estimation**
```
Player considering new contract: "500 units of Engine v3"

PLM provides instant cost breakdown:
Material Costs:
- Aluminum: 500× 25kg × $4.20/kg = $52,500
- Steel bolts: 12,000× $0.35 = $4,200
- Gaskets: 1,000× $1.80 = $1,800
- Subtotal: $58,500 ($117/unit)

Labor Costs (from routing):
- CNC time: 500× 30min @ $48/hr = $12,000
- Assembly: 500× 20min @ $36/hr = $6,000
- QC: 500× 5min @ $42/hr = $1,750
- Subtotal: $19,750 ($39.50/unit)

Overhead (allocated):
- Machine depreciation, utilities, floor space
- Subtotal: $11,250 ($22.50/unit)

Total Cost: $89,500 ($179/unit)

Customer offers: $220/unit
Potential Gross Margin: $20,500 (22.9%)

Player Decision: Accept (good margin) or Negotiate for higher price?
```

---

## 4.4 Process Routing (How to Make It)

### 4.4.1 Routing Structure

A **routing** defines the **ordered sequence of operations** to transform raw material into finished part.

```
Routing ID: RT-ENG-BLK-v2
Part: Cylinder Block v2
Version: 2.0
Effective Date: 2025-12-01

Operation Sequence:
┌─────┬──────────┬─────────┬──────────┬────────────────────┐
│ Seq │ Op ID    │ Name    │ Machine  │ Cycle Time (min)   │
├─────┼──────────┼─────────┼──────────┼────────────────────┤
│ 010 │ OP-010   │ Receive │ Dock     │ 2                  │
│ 020 │ OP-020   │ QC Raw  │ QC_Sta01 │ 3                  │
│ 030 │ OP-030   │ Rough   │ CNC_Mill │ 12                 │
│ 040 │ OP-040   │ Finish  │ CNC_Mill │ 18                 │
│ 050 │ OP-050   │ Deburr  │ Manual   │ 8                  │
│ 060 │ OP-060   │ QC Dim  │ CMM      │ 5                  │
│ 070 │ OP-070   │ Clean   │ Washer   │ 4                  │
│ 080 │ OP-080   │ Final QC│ QC_Sta02 │ 3                  │
│ 090 │ OP-090   │ Package │ Bench    │ 2                  │
└─────┴──────────┴─────────┴──────────┴────────────────────┘

Total Cycle Time: 57 minutes
```

### 4.4.2 Operation Details

Each operation has detailed metadata:

```json
{
  "opID": "OP-030",
  "opName": "Roughing",
  "description": "Remove bulk material to near-net shape",
  "sequenceNum": 30,
  "allowedMachineTypes": ["CNC_Mill", "Vertical_MC"],
  "preferredMachine": "CNC_Mill",
  
  "parameters": {
    "ncProgram": "PROG_ENG_BLK_V2_ROUGH.nc",
    "spindleRPM": 2500,
    "feedRate": 250,
    "cutDepth": 2.0,
    "coolantFlow": 10,
    "tool": {
      "type": "EndMill_12mm_HSS",
      "expectedLife": 500,
      "currentWear": null  // Assigned at runtime
    }
  },
  
  "setup": {
    "setupTime_min": 15,
    "requiredSkill": "CNC_Operator_L2",
    "toolingRequired": ["EM-12-HSS", "Vise_150mm"],
    "fixtureRequired": "FIX-ENG-BLK-v2"
  },
  
  "quality": {
    "checkpoints": [
      {"feature": "overall_dimensions", "tolerance": 0.5, "method": "caliper"}
    ],
    "sampleRate": 0.10,  // 10% sampling
    "criticalOperation": false
  },
  
  "timing": {
    "baseCycleTime_min": 12,
    "setupTime_min": 15,
    "teardownTime_min": 2
  },
  
  "safety": {
    "requiresPPE": ["safety_glasses", "hearing_protection"],
    "lockoutRequired": false,
    "twoPersonRule": false
  }
}
```

### 4.4.3 Alternative Routings

Some parts support **multiple routing options** (player choice):

```
Cylinder Block v2: Two Routing Options

Option A: "High Volume" (Default)
- Uses automated CNC for all operations
- Faster setup (15 min)
- Higher throughput (12 min cycle)
- Requires skilled CNC operator
- Cost: $28/part labor

Option B: "Low Volume / High Mix"
- Uses manual mill + skilled machinist
- Slower setup (30 min)
- Longer cycle (25 min)
- More flexible (easier to switch variants)
- Cost: $45/part labor

Player Decision:
- Use Option A for contracts >50 units
- Use Option B for small batches (<20 units) or prototypes
```

**MES Integration:**
```
Player selects routing at work order creation:
- Contract requires 200 units → MES suggests "High Volume" routing
- Player accepts → MES loads RT-ENG-BLK-v2-HV
- All 200 parts follow same routing automatically
```

---

## 4.5 Engineering Change Orders (ECOs)

### 4.5.1 ECO Triggers

ECOs are triggered by:
1. **Customer Request:** "We need torque increased from 85 to 95 Nm"
2. **Quality Issue:** "5% scrap rate on bore dimension - tighten tolerance"
3. **Cost Reduction:** "Switching from Grade 10.9 to 8.8 bolts saves $2/unit"
4. **Regulatory:** "New EPA standard requires low-emission machining"
5. **Obsolescence:** "Supplier discontinued aluminum alloy - need substitute"

### 4.5.2 ECO Workflow

```
┌─────────────┐
│ ECO Request │
│ (Initiated) │
└──────┬──────┘
       ↓
┌──────┴───────────────┐
│ Engineering Review   │
│ - Feasibility        │
│ - Cost Impact        │
│ - Timeline           │
└──────┬───────────────┘
       ↓
┌──────┴───────────────┐
│ Player Approval      │ ← Decision Point
│ Accept / Modify /    │
│ Reject               │
└──────┬───────────────┘
       ↓ (If Accepted)
┌──────┴───────────────┐
│ Implementation       │
│ - Update BOM         │
│ - Update Routing     │
│ - Update MES Rules   │
│ - Retrain Workers    │
│ - Update QC Criteria │
└──────┬───────────────┘
       ↓
┌──────┴───────────────┐
│ Verification         │
│ - Produce samples    │
│ - Validate changes   │
│ - Customer approval  │
└──────┬───────────────┘
       ↓
┌──────┴───────────────┐
│ Full Production      │
│ (New version active) │
└──────────────────────┘
```

### 4.5.3 ECO Example (Detailed)

**Scenario:** Customer requests torque upgrade for Engine v2

```
┌─ ECO-2025-078: Torque Upgrade ────────────────────────┐
│                                                        │
│ Requestor: Customer (OEM Contract CO-2025-42)         │
│ Date Submitted: 2025-12-15                            │
│ Priority: High (contractually required)               │
│                                                        │
│ Description:                                           │
│ Increase cylinder head bolt torque from 85 Nm to 95Nm│
│ to meet updated safety standard ASME-B1.2-2025        │
│                                                        │
│ ══════════════════════════════════════════════════════ │
│ IMPACT ANALYSIS (Auto-Generated by PLM):              │
│ ══════════════════════════════════════════════════════ │
│                                                        │
│ Affected Components:                                   │
│ • M12 Cylinder Head Bolts (20 per engine)             │
│   Current: Grade 8.8 (max torque 90 Nm)              │
│   Required: Grade 10.9 (max torque 120 Nm)           │
│   Cost Impact: +$0.25/bolt × 20 = +$5/engine         │
│                                                        │
│ Affected Operations:                                   │
│ • OP-065: Cylinder Head Bolting (Assembly)            │
│   Current Torque: 85 Nm ± 3 Nm                       │
│   New Torque: 95 Nm ± 1 Nm (tighter tolerance)       │
│   Sequence: Unchanged                                 │
│                                                        │
│ MES Changes Required:                                  │
│ • Update Atlas Nutrunner rule:                        │
│   IF Part.version == "v2_ECO78" THEN torque = 95     │
│ • Update QC sampling: 5% → 10% (higher scrutiny)     │
│                                                        │
│ Worker Training:                                       │
│ • 4 assembly workers need recertification            │
│ • Training time: 2 hours each = 8 hours total        │
│ • Training cost: $320 (@ $40/hr)                      │
│                                                        │
│ Timeline:                                              │
│ • Bolt procurement: 5 business days                  │
│ • MES rule update: 1 day                             │
│ • Worker training: 1 day                             │
│ • Sample validation: 2 days                          │
│ Total: 9 business days until full production          │
│                                                        │
│ ══════════════════════════════════════════════════════ │
│ COST ANALYSIS:                                         │
│ ══════════════════════════════════════════════════════ │
│ Recurring Costs (per engine):                         │
│   Material: +$5.00 (higher grade bolts)              │
│   Labor: +$0.50 (slightly longer cycle)              │
│   Total: +$5.50/engine                                │
│                                                        │
│ One-Time Costs:                                        │
│   Worker training: $320                               │
│   Sample validation: $180 (3 sample engines)          │
│   MES programming: $0 (player task)                   │
│   Total: $500                                          │
│                                                        │
│ Contract Impact:                                       │
│   Remaining units: 450                                │
│   Additional cost: 450 × $5.50 = $2,475               │
│   + One-time: $500                                    │
│   Total ECO Cost: $2,975                              │
│                                                        │
│   Customer agreed to: $4 price increase/unit          │
│   Revenue offset: 450 × $4 = $1,800                   │
│   Net Cost: -$1,175                                   │
│                                                        │
│ ══════════════════════════════════════════════════════ │
│ RECOMMENDATION:                                        │
│ ══════════════════════════════════════════════════════ │
│ Accept ECO with condition: Negotiate +$7/unit to      │
│ achieve cost neutrality.                              │
│                                                        │
│ Justification to customer:                            │
│ "95 Nm torque requires Grade 10.9 bolts (25% higher  │
│  material cost) + tighter QC (10% more inspection).   │
│  This ensures safety compliance with ASME-B1.2-2025   │
│  standard. Proposed $7 increase covers our costs."    │
│                                                        │
│ [Negotiate] [Accept as-is] [Reject ECO] [Defer]       │
└────────────────────────────────────────────────────────┘
```

**Player Decision Paths:**

**Path A: Negotiate (Recommended)**
- Contact customer, request $7/unit increase
- If accepted: Implement ECO, maintain margin
- If rejected: Proceed to Path B or C

**Path B: Accept as-is**
- Implement ECO, absorb $1,175 cost
- Justification: Preserve customer relationship for future contracts
- Strategic if: This customer represents >20% annual revenue

**Path C: Reject ECO**
- Inform customer cannot meet new spec at current price
- Risk: Customer cancels contract (lose $81,000 remaining revenue)
- Only viable if: Alternative customers available

**Path D: Defer**
- Request extension: "Need 2 weeks to engineer cost-neutral solution"
- R&D team explores alternatives (different bolt design, optimized assembly)
- Risky: Customer may not wait

### 4.5.4 ECO Implementation (Gameplay)

**Player selects "Accept" (Path B for example):**

1. **PLM Updates (Automatic):**
   ```
   - BOM v2.0 → v2.1 (new bolt part number)
   - Routing RT-ENG-BLK-v2 → RT-ENG-BLK-v2.1 (updated torque spec)
   - Part Number: ENG-v2 → ENG-v2_ECO78
   - Effectivity: Engines produced after 2025-12-24
   ```

2. **MES Updates (Player Action Required):**
   ```
   Player opens MES Rule Editor:
   
   Existing Rule:
   IF Part.version == "v2" THEN
     Nutrunner.torque = 85
   
   Updated Rule:
   IF Part.version == "v2_ECO78" THEN
     Nutrunner.torque = 95
     Nutrunner.tolerance = 1
     QC.sampleRate = 0.10
   ELSEIF Part.version == "v2" THEN
     Nutrunner.torque = 85
   END
   
   Player saves, MES simulates:
   "Rule will correctly apply 95 Nm to all new v2_ECO78 parts"
   "Existing v2 parts (legacy inventory) will continue at 85 Nm"
   ```

3. **ERP Purchase Order (Automatic):**
   ```
   Order: 500× M12 Grade 10.9 Bolts
   Supplier: McMaster-Carr
   Unit Price: $0.60 (vs $0.35 for Grade 8.8)
   Total: $300
   Delivery: 5 business days
   ```

4. **Worker Training (Player Schedules):**
   ```
   Player assigns 4 workers to training:
   - Carlos, Maria, David, Jane
   - Duration: 2 hours each (can run concurrent sessions)
   - Trainer: Senior assembler (already certified on 95 Nm)
   - Schedule: Day 7 (after bolts arrive, before production restart)
   
   Training Content:
   - New torque spec: 95 Nm ± 1 Nm
   - Importance of tight tolerance (safety-critical)
   - Atlas Nutrunner calibration verification
   - Updated work instructions review
   ```

5. **Validation Run (Day 8):**
   ```
   Produce 3 sample engines with new spec:
   
   Sample 1: All bolts 94.8-95.2 Nm ✓ PASS
   Sample 2: All bolts 94.9-95.1 Nm ✓ PASS
   Sample 3: Bolt A3: 96.5 Nm ✗ FAIL (out of tolerance)
   
   Root Cause: Worker_David unfamiliar with tighter tolerance, 
                applied excessive pressure
   
   Corrective Action: Additional hands-on practice for David (1 hour)
   Re-test: Sample 4 produced by David → All bolts in spec ✓
   
   Validation Result: ECO implementation verified, full production approved
   ```

6. **Full Production Restart (Day 9):**
   ```
   MES begins using new routing RT-ENG-BLK-v2.1
   All engines produced after this point = ENG-v2_ECO78
   Quality metrics monitored closely for first 20 units
   
   Results (first 50 units):
   - Scrap rate: 2.1% (slightly elevated due to learning curve)
   - Torque compliance: 98.5% (excellent)
   - Customer sampling: 5 units sent for validation
   
   Customer Approval (Day 12):
   "Samples meet ASME-B1.2-2025 standard. Approved for full production."
   
   Contract resumes, remaining 450 units produced at new spec.
   ```

---

## 4.6 Multi-Version Product Management

### 4.6.1 Concurrent Version Production

**Challenge:** Produce v1, v2, and v2_ECO78 simultaneously on same line

**PLM Configuration:**
```
Product: Engine Block Assembly
Active Versions:
1. v1 (Legacy)
   - Still producing for Contract CO-2024-18 (ends in 2 weeks)
   - BOM: BOM-ENG-v1.2
   - Routing: RT-ENG-v1.2
   - Torque: 75 Nm

2. v2 (Standard)
   - Main product for most contracts
   - BOM: BOM-ENG-v2.0
   - Routing: RT-ENG-v2.0
   - Torque: 85 Nm

3. v2_ECO78 (Upgraded)
   - For Contract CO-2025-42 only
   - BOM: BOM-ENG-v2.1
   - Routing: RT-ENG-v2.1
   - Torque: 95 Nm

PLM Challenges:
- 3 different BOMs (different bolt grades)
- 3 different routings (different torque specs)
- MES must select correct recipe per part
- Workers must not confuse versions
- QC must apply correct tolerances
```

**MES Solution (from Section 3.5):**
```
Smart Part Tagging (RFID):
- Each part carrier tagged with version
- Nutrunner reads tag → applies correct torque
- HMI displays active version → worker sees clearly
- QC station reads tag → applies correct tolerances

Result: Zero version confusion, seamless mixed production
```

### 4.6.2 Version Transition Strategy

**Scenario:** Transitioning from v2 to v2_ECO78

**Option A: Hard Cutover (Risky)**
```
Timeline:
Day 1: Stop v2 production
Day 1-9: Implement ECO (procurement, training, validation)
Day 10: Resume with v2_ECO78 only

Risks:
- 9 days of zero production (backlog accumulates)
- Rush transition may cause quality issues
- No buffer inventory if issues arise

Suitable when: ECO is simple, low-risk, short timeline
```

**Option B: Phased Transition (Safe)**
```
Timeline:
Day 1: Begin ECO implementation (bolts ordered)
Day 1-9: Continue producing v2 (build inventory buffer)
Day 9: 450 units of v2 in finished goods (safety stock)
Day 10: Switch to v2_ECO78 production
Day 10-14: Consume v2 inventory while ramping v2_ECO78
Day 15: Fully transitioned, v2 inventory depleted

Benefits:
- Zero production downtime
- Buffer inventory covers unexpected issues
- Gradual ramp-up of new version

Cost:
- Higher inventory holding ($4,500 for 10 days @ $10/unit/day storage)
- Suitable when: ECO is complex or high-risk
```

**Player Choice:**
```
┌─ ECO TRANSITION STRATEGY ─────────────────────┐
│                                               │
│ Choose implementation approach:               │
│                                               │
│ ○ Hard Cutover                                │
│   - Stop v2 immediately                       │
│   - 9 days production halt                   │
│   - Resume Day 10 with v2_ECO78              │
│   Cost: $0 inventory, $8,100 opportunity cost│
│                                               │
│ ● Phased Transition (Recommended)            │
│   - Continue v2 until Day 9                  │
│   - Build 450-unit safety stock              │
│   - Switch Day 10, consume buffer            │
│   Cost: $4,500 inventory holding             │
│                                               │
│ ○ Parallel Production (Advanced)             │
│   - Run v2 AND v2_ECO78 simultaneously       │
│   - Requires 2nd assembly line or AGVs       │
│   - Zero transition risk                     │
│   Cost: $12,000 (2nd line setup)             │
│   Requires: Tier 4 MES + AGV system          │
│                                               │
│ [Confirm Selection]                           │
└───────────────────────────────────────────────┘
```

---

## 4.7 Product Definition Layer (PDL)

### 4.7.1 PDL Concept

The **Product Definition Layer** is PLM's **master data structure** that combines:
- BOM (what parts)
- Routing (how to make)
- Specifications (quality requirements)
- Customer requirements (contract overrides)
- MES templates (machine parameters)

**Purpose:** Single source of truth that feeds all downstream systems

### 4.7.2 PDL Data Model

```json
{
  "productID": "ENG-v2_ECO78",
  "name": "Engine Block Assembly v2 (ECO-078)",
  "version": "2.1",
  "effectiveDate": "2025-12-24",
  "status": "Active",
  
  "bom": {
    "bomID": "BOM-ENG-v2.1",
    "components": [
      {
        "partID": "CYL-BLK-v2",
        "name": "Cylinder Block",
        "qty": 1,
        "material": "Aluminum_6061_T6",
        "weight_kg": 12.5,
        "tolerance_mm": 0.05,
        "criticality": "high",
        "traceability": true
      },
      {
        "partID": "BOLT-M12-10.9",
        "name": "Cylinder Head Bolt M12 Grade 10.9",
        "qty": 20,
        "material": "Steel_Grade_10.9",
        "torqueSpec": {
          "target_Nm": 95,
          "tolerance_Nm": 1,
          "angle_deg": null,
          "sequence": ["A1", "A4", "A2", "A3", "repeat2x"]
        },
        "criticality": "high",
        "traceability": true
      }
    ]
  },
  
  "routing": {
    "routingID": "RT-ENG-v2.1",
    "operations": [
      {
        "opID": "OP-065",
        "name": "Cylinder Head Bolting",
        "machine": "Atlas_Nutrunner",
        "parameters": {
          "torque_Nm": 95,
          "tolerance_Nm": 1,
          "speed_RPM": 25,
          "verification": "MES_logged"
        },
        "baseCycleTime_min": 8,
        "setupTime_min": 2,
        "qcSampleRate": 0.10
      }
    ]
  },
  
  "specifications": {
    "dimensionalTolerances": {
      "bore_diameter_mm": {"nominal": 85.00, "tolerance": 0.05},
      "deck_height_mm": {"nominal": 200.00, "tolerance": 0.10}
    },
    "functionalTests": [
      {"test": "PressureTest", "minPSI": 150, "maxPSI": 200}
    ]
  },
  
  "contractOverrides": {
    "contractID": "CO-2025-42",
    "maxDefectRate": 0.02,  // 2% max (tighter than standard 3%)
    "deliveryPriority": "high",
    "specialInstructions": "Expedite QC - safety-critical application"
  },
  
  "mesTemplate": {
    "ruleSetID": "MES-ENG-v2_ECO78",
    "autoGenerated": true,
    "customRules": [
      {
        "trigger": "PartArrive_at_Nutrunner",
        "condition": "Part.version == 'v2_ECO78'",
        "actions": [
          {"type": "setParameter", "param": "torque", "value": 95},
          {"type": "setParameter", "param": "tolerance", "value": 1},
          {"type": "setParameter", "param": "qcSampleRate", "value": 0.10}
        ]
      }
    ]
  },
  
  "qualityCriteria": {
    "aoql": 0.02,  // Acceptable Quality Level
    "samplingPlan": "MIL-STD-105E_Level_II",
    "criticalDefects": ["bore_out_of_spec", "torque_out_of_spec"],
    "majorDefects": ["surface_finish_poor"],
    "minorDefects": ["cosmetic_blemish"]
  }
}
```

### 4.7.3 PDL → MES Auto-Generation

When a new product/version is approved in PLM, **MES rules are auto-generated**:

```
Player Action: Approve ECO-078 in PLM
↓
PLM generates PDL for ENG-v2_ECO78
↓
MES reads PDL, creates base rule template:

Auto-Generated MES Rule:
function onPartArrive_Nutrunner(part)
  if part.productID == "ENG-v2_ECO78" then
    -- From PDL.routing.operations[OP-065].parameters
    nutrunner.setTorque(95, tolerance=1)
    nutrunner.setSpeed(25)  -- RPM
    
    -- From PDL.routing.operations[OP-065].qcSampleRate
    qc.sampleRate = 0.10
    
    -- From PDL.bom.components[BOLT-M12-10.9].torqueSpec
    sequence = {"A1", "A4", "A2", "A3"}
    enforceSequence(sequence)
    
    -- From PDL.contractOverrides
    if getCurrentContract() == "CO-2025-42" then
      alertPlayer("High-priority contract - expedite QC")
    end
  end
end

Player Options:
[Accept Auto-Generated Rule] (Use as-is, fast deployment)
[Customize] (Edit in MES editor, add optimizations)
[Test in Simulation] (Validate before deploying)
```

**Player Value:**
- **Casual:** Accept auto-generated = instant MES configuration, no coding required
- **Strategic:** Customize = add efficiency optimizations, fine-tune
- **Expert:** Fully custom = write advanced logic, predictive adjustments

---

## 4.8 PLM-Driven Quality Management

### 4.8.1 Tolerance Propagation

PLM defines tolerances at the **feature level**, which propagate to **QC inspection criteria**:

```
PLM Specification:
Part: Cylinder Block v2
Feature: Bore Diameter
  Nominal: 85.00 mm
  Tolerance: ±0.05 mm (85.00 - 0.05 to 85.00 + 0.05)
  Criticality: High (affects engine function)
  Inspection Method: CMM (Coordinate Measuring Machine)
  Sample Rate: 10% (due to criticality)

↓ (Propagates to QC System)

QC Inspection Criteria:
- Measure bore diameter on CMM
- Accept range: 84.95 mm to 85.05 mm
- If out of range → Scrap (high criticality, no rework)
- Sample 1 of every 10 parts
- Log all measurements for SPC analysis
```

**Gameplay Impact:**
```
Scenario: Player tightens tolerance (reduces from ±0.05 to ±0.02)

PLM Effect:
- Updated specification stored
- MES notified of change
- QC criteria auto-updated to 84.98-85.02 mm range

Production Impact:
- Scrap rate increases from 3% to 8% (tighter spec harder to meet)
- Player must:
  A. Accept higher scrap (reduces margin)
  B. Slow down machining (tighter control, lower throughput)
  C. Invest in better machine/tooling (capex)
  D. Reject the tighter tolerance (if customer-requested, negotiate)
```

### 4.8.2 Sampling Strategy (AQL)

PLM defines **Acceptable Quality Level (AQL)** per product, driving QC sampling:

```
Product: Engine v1 (Mature, low-risk)
AQL: 0.015 (1.5% defect rate acceptable)
Sampling Plan: MIL-STD-105E, Inspection Level II, AQL 1.5%
Sample Size (for lot of 500): 80 units (16%)

Product: Engine v3 (New, high-risk)
AQL: 0.004 (0.4% defect rate acceptable)
Sampling Plan: MIL-STD-105E, Inspection Level III, AQL 0.4%
Sample Size (for lot of 500): 200 units (40%)

MES Automation:
- Reads AQL from PLM
- Calculates sample size per MIL-STD-105E tables
- Instructs QC station which parts to inspect
- Worker just follows green light indicators (no math needed)
```

---

## 4.9 Part Phasing & Lifecycle Management

### 4.9.1 Introduction Phase

**Challenge:** Launching a brand new product

**PLM Workflow:**
```
Week 1-2: R&D Design
- Engineering team creates BOM, routing
- Cost estimates generated
- Player reviews, adjusts specs if needed

Week 3: Prototype Production
- Produce 5 sample units
- Validate: fit, function, manufacturing feasibility
- Iterate if needed (may extend timeline)

Week 4: Pilot Run
- Produce 50 units at full scale
- Monitor: cycle times, scrap rate, worker feedback
- Adjust: routing parameters, tooling, MES rules

Week 5+: Full Production
- Product status: "Active"
- MES uses finalized routing/parameters
- Quality data feeds back to PLM for continuous improvement
```

**Scrap Rate Curve (Learning Curve):**
```
Parts 1-10:   15% scrap (initial learning)
Parts 11-50:  8% scrap (workers gaining experience)
Parts 51-100: 5% scrap (process stabilizing)
Parts 101-500: 3% scrap (mature process)
Parts 501+:   2% scrap (optimized)

Player Strategy: Factor higher scrap into first contract pricing
```

### 4.9.2 Maturity Phase

**Characteristics:**
- Stable BOM (few ECOs)
- Lowest scrap rates (experienced workers, optimized MES)
- Highest margins (R&D fully amortized)
- Highest volumes (customer confidence)

**PLM Metrics:**
```
Product: Engine v2 (Year 2 of production)

Stability Indicators:
- ECOs: 0.5 per quarter (very stable)
- Scrap Rate: 1.8% (excellent)
- Customer Returns: 0.2% (industry-leading)
- Production Volume: 2,500 units/month (peak)

Profitability:
- R&D Cost (amortized): $0.50/unit (paid off)
- Material + Labor: $155/unit
- Selling Price: $220/unit
- Gross Margin: $64.50/unit (29.3%)

Strategic Decision: Maximize volume, prepare next-gen product
```

### 4.9.3 Phase-Out Strategy

**Trigger:** New version ready (Engine v3 replacing v2)

**PLM Phase-Out Plan:**
```
Quarter 1: Announce End-of-Life (EOL)
- Notify customers: "v2 EOL in 12 months, transition to v3"
- Accept final v2 orders (with cutoff date)
- Begin v3 production ramp-up

Quarter 2-3: Dual Production
- Produce v2 AND v3 simultaneously
- v2 volume declining (80% → 50% → 20%)
- v3 volume ramping (20% → 50% → 80%)

Quarter 4: Final v2 Production
- Produce last v2 orders
- Retain spare parts inventory (service/warranty support)
- Release v2 tooling/fixtures for sale or scrap

Year 2+: Obsolete
- v2 status: "Obsolete - Service Only"
- Maintain documentation for warranty repairs
- Occasional small batches for aftermarket (high margin)
```

**Inventory Management:**
```
Problem: 450 M12 Grade 8.8 bolts remaining (v2-specific)
Options:
A. Scrap ($157.50 loss)
B. Sell to surplus dealer ($50 recovery)
C. Repurpose for other products (if compatible)
D. Store for warranty service (holding cost $5/month)

Player Decision: 
- If v3 uses same bolts → Option C (zero waste)
- If incompatible → Option B (minimize loss)
- Strategic: Plan phase-outs to minimize stranded inventory
```

---

## 4.10 PLM & Contract Integration

### 4.10.1 Customer-Specific Products

Some contracts require **customer-specific modifications**:

```
Base Product: Engine v2
Customer: Industrial Pump Corp.
Modification Request:
- Custom mounting holes (4 additional M8 threaded inserts)
- Corrosion-resistant coating (marine application)
- Extended QC (100% pressure testing vs. standard 5% sampling)

PLM Response:
Create Derivative Product: ENG-v2-IPC-Marine
- Inherits base v2 BOM + routing
- Adds:
  - 4× M8 threaded inserts
  - Operation OP-085: Apply Marine Coating (12 min cycle)
  - Operation OP-095: Pressure Test All Units (8 min cycle)
- Cost Impact: +$28/unit
- Cycle Time Impact: +20 min/unit

Contract Negotiation:
- Customer offers: $240/unit (vs $220 standard)
- Player cost: $183/unit (vs $155 standard)
- Margin: $57/unit (still 23.8%, acceptable)

Player Decision: Accept custom product development
```

**PLM Benefit:**
- **Derivative products** leverage existing BOM/routing (90% reuse)
- Faster development (weeks vs. months for new product)
- Lower risk (proven base design)

### 4.10.2 Multi-Customer Portfolio

**Challenge:** Managing 5+ active products across different customers

**PLM Dashboard:**
```
┌─ PRODUCT PORTFOLIO OVERVIEW ──────────────────────────┐
│                                                        │
│ Product          Ver   Customer    Vol/Mo  Margin     │
│ Engine Basic     v1    General     800     22%        │
│ Engine Standard  v2    Multi       2,500   29%  ← Star│
│ Engine ECO       v2.1  OEM-A       450     28%        │
│ Engine Premium   v3    Multi       150     35%  ← Rising│
│ Engine Custom    v2-IPC Pump Corp  80      24%        │
│                                                        │
│ Total Volume: 3,980 units/month                        │
│ Weighted Avg Margin: 28.4%                             │
│                                                        │
│ Capacity Utilization: 87% (healthy)                    │
│ Bottleneck: CNC Machining (92% utilized)               │
│                                                        │
│ Strategic Recommendations:                             │
│ • Phase out v1 (low margin, declining demand)          │
│ • Expand v2 production (highest margin + volume)       │
│ • Invest in v3 marketing (growth potential)            │
│ • Add 2nd CNC to relieve bottleneck                    │
│                                                        │
│ [Detailed Analysis] [Capacity Planning] [Profitability]│
└────────────────────────────────────────────────────────┘
```

**Player Decisions:**
- Which products to prioritize?
- When to phase out low-performers?
- How to allocate limited capacity?
- Where to invest in expansion?

---

## 4.11 PLM Progression & Unlocks

**Tier 0-1 (Levels 1-5):**
- Simple products (single-version engines)
- Basic BOM (5-10 components)
- Simple routings (3-5 operations)
- No ECOs (products static)

**Tier 2 (Levels 6-10):**
- Multi-version products (v1, v2)
- Moderate BOM (10-20 components)
- Complex routings (5-10 operations)
- Basic ECOs (material/spec changes)

**Tier 3 (Levels 11-15):**
- Portfolio management (3-5 products)
- Advanced BOM (20-30 components, sub-assemblies)
- Alternative routings (high/low volume options)
- Advanced ECOs (functional changes, cost reductions)

**Tier 4 (Levels 16-20):**
- Large portfolio (5-10 products)
- Custom derivatives (customer-specific products)
- Automated MES template generation
- Phase-out planning tools

**Tier 5 (Levels 21-25):**
- Global product lines (10+ products)
- Platform architectures (shared components across products)
- AI-driven cost optimization
- Digital thread (full traceability across enterprise)

---

## 4.12 Integration Summary

**PLM Connects To:**

| System | Data Flow | Purpose |
|--------|-----------|---------|
| **ERP** | BOM → Material requirements | Procurement planning |
| **MES** | Routing → Machine parameters | Production execution |
| **QC** | Specs → Inspection criteria | Quality assurance |
| **Contracts** | Products → Customer deliverables | Order fulfillment |
| **R&D** | New designs ← Development | Innovation pipeline |
| **Costing** | BOM+Routing → Cost estimates | Pricing decisions |

**Player Value:**
- **Single source of truth:** No conflicting information
- **Automatic propagation:** Changes flow to all systems
- **Traceability:** Full genealogy from raw material to customer
- **Decision support:** Cost/margin analysis for every product

---

**End of Section 4 - PLM System**

---

# 5. R&D SYSTEM & CUSTOMER CONTRACTS

## 5.1 Overview & Strategic Importance

**R&D (Research & Development)** and **Customer Contracts** form the **business strategy layer** of Engine Assembly Tycoon. While factory operations determine execution efficiency, R&D and contracts determine **what** you produce and **for whom**.

**Core Design Philosophy:**
- **Strategic Choices Matter:** Co-develop vs. OEM vs. In-House significantly impacts long-term profitability
- **Risk vs. Reward:** Higher R&D investment = higher margins (but higher risk)
- **Relationship Building:** Customer satisfaction unlocks better contracts
- **Portfolio Management:** Balance stable (low-margin OEM) with high-margin (in-house) products

---

## 5.2 Customer Types & Characteristics

### 5.2.1 OEM (Original Equipment Manufacturer)

**Profile:**
- Established automotive/industrial companies
- Fixed product specifications (they own the design)
- High volume, stable demand
- Moderate-to-low margins

**Contract Structure:**
```
Customer: General Motors (OEM)
Product: Engine Model GM-2.0L-Standard
Volume: 1,000 units/month
Duration: 24 months (with renewal option)
Payment: $450 per unit
Margin: 22% (after materials, labor, overhead)

Requirements:
- Quality: <1% defect rate
- Delivery: Weekly shipments (250/week)
- Traceability: Full genealogy required
- Penalties: $2,000/day late, $500/defective unit
- Bonus: +$25,000 if zero defects for 6 months
```

**Advantages:**
- ✓ Low risk (specs proven, demand predictable)
- ✓ No R&D cost (they provide designs)
- ✓ Steady cash flow
- ✓ Easy to scale (simple production)

**Disadvantages:**
- ✗ Low margins (competitive bidding)
- ✗ No IP ownership (can't sell to others)
- ✗ Rigid specs (no innovation)
- ✗ Vulnerable to contract loss (customer can switch suppliers)

**Gameplay Implications:**
- Ideal for early game (stable revenue while learning)
- Foundation for cash flow (pays the bills)
- Can become boring late-game (no strategic depth)

---

### 5.2.2 Startup / Boutique Manufacturer

**Profile:**
- Small, innovative companies
- Willing to collaborate on design
- Low-to-medium volume
- High margins (niche products)

**Contract Structure:**
```
Customer: GreenDrive Motors (Electric Vehicle Startup)
Product: High-Efficiency Electric Motor Controller
Volume: 200 units/month (growing to 500 in Year 2)
Duration: 12 months + options
Payment: $1,200 per unit
Margin: 38% (premium pricing for specialty)

Requirements:
- Flexibility: Expect design changes (ECOs common)
- Quality: <0.5% defect (critical for brand reputation)
- Innovation: Open to process improvements
- Exclusivity: 18-month exclusive supply agreement

Special Clause:
- If customer achieves $50M funding, volume increases 3×
- Profit-sharing: 5% of gross profit on units >500/month
```

**Advantages:**
- ✓ High margins (premium pricing)
- ✓ Collaborative (you influence design)
- ✓ Upside potential (if startup succeeds)
- ✓ Innovation-friendly (try new techniques)

**Disadvantages:**
- ✗ High risk (startups can fail)
- ✗ Volatile demand (funding-dependent)
- ✗ Frequent ECOs (design instability)
- ✗ Payment risk (may be slow to pay)

**Gameplay Implications:**
- High-risk, high-reward play style
- Requires agile production (MES critical for ECO handling)
- Exciting narratively (support underdog success)
- Late-game diversification strategy

---

### 5.2.3 Co-Development Partner

**Profile:**
- Medium-sized companies wanting shared R&D
- Split costs and IP ownership
- Medium volume, medium margins
- Long-term strategic partnerships

**Contract Structure:**
```
Customer: Industrial Pump Corporation
Product: Variable-Speed Pump Motor (Co-Developed)
R&D Split: 60% IPC, 40% Player
IP Ownership: 50/50 joint ownership
Volume: 500 units/month
Duration: 36 months
Payment: $680 per unit
Margin: 31%

Co-Development Terms:
- R&D Investment (Player): $120,000 over 6 months
- R&D Investment (IPC): $180,000 over 6 months
- Revenue Split on External Sales: 50/50
- Player can sell to other pump manufacturers after Year 1
- IPC has right of first refusal on capacity (priority production)

Shared Benefits:
- Both parties contribute engineers (3 from player, 5 from IPC)
- Joint IP = both can license to third parties
- Knowledge transfer (player learns pump-specific requirements)
```

**Advantages:**
- ✓ Shared R&D cost (lower financial risk)
- ✓ IP ownership (can sell to others later)
- ✓ Knowledge gain (learn new domain)
- ✓ Strategic partnership (long-term relationship)

**Disadvantages:**
- ✗ Shared profits (split revenue on external sales)
- ✗ Complexity (joint decision-making)
- ✗ Coordination overhead (meetings, alignment)
- ✗ Potential conflict (disagreements on design)

**Gameplay Implications:**
- Balanced risk/reward
- Teaches collaboration mechanics
- Gateway to multiple industries (diversification)
- Unlocks mid-game strategic options

---

### 5.2.4 In-House Product Development

**Profile:**
- Player-owned product (100% IP)
- Player funds 100% of R&D
- Can sell to anyone
- Highest margins (if successful)

**Development Structure:**
```
Product: Player-Designed "EcoEngine Pro" (Fuel-Efficient Engine)
R&D Investment: $250,000
R&D Duration: 9 months (3 engineers full-time)
Market Research: $15,000 (identify demand)
Prototype Costs: $40,000 (build and test)
Certification: $35,000 (emissions, safety)

Total Investment: $340,000

Sales Strategy:
- Target Market: Small automotive manufacturers, retrofit market
- Pricing: $850 per unit
- Margin: 45% (no revenue sharing)
- Estimated Volume: 300 units/month (ramp to 800 over 2 years)

Risk Factors:
- Market acceptance uncertain (might flop)
- Competition (established players may undercut)
- Regulatory changes (emissions standards shift)
- Technology obsolescence (EV trend might kill demand)

Success Scenario:
Year 1: 200 units/month avg, Revenue $2.04M, Profit $918k
Year 2: 600 units/month avg, Revenue $6.12M, Profit $2.75M
Payback: 5 months (if ramp goes as planned)

Failure Scenario:
Market rejects product, sell only 50 units/month
Revenue $510k/year, Profit $230k/year
Payback: Never (loses $110k)
```

**Advantages:**
- ✓ Maximum margins (45%+ possible)
- ✓ Full control (design, pricing, customers)
- ✓ Scalability (unlimited upside)
- ✓ Strategic asset (valuable IP)

**Disadvantages:**
- ✗ Highest risk (could fail completely)
- ✗ Large upfront cost ($300k+ typical)
- ✗ Long payback period (6-12 months)
- ✗ Market uncertainty (demand unknown)

**Gameplay Implications:**
- Endgame strategy (requires capital)
- High skill ceiling (must understand market)
- Exciting success (build empire on own products)
- Educational (teaches entrepreneurship)

---

## 5.3 R&D Mechanics

### 5.3.1 R&D Resources

**Engineers:**
```
Engineer Profile:
- Skill Level: 1-100 (affects R&D speed and success rate)
- Specialization: Mechanical, Electrical, Software, Materials
- Experience: Levels up with projects (faster R&D over time)
- Salary: $5,000-$9,000/month (skill-dependent)
- Availability: Can work on R&D OR production support (not both)

Example Team:
Engineer_Sarah (Mechanical, Skill 85): $7,500/mo
Engineer_Tom (Electrical, Skill 72): $6,200/mo
Engineer_Lisa (Materials, Skill 68): $5,800/mo

Total Monthly Cost: $19,500
Productivity: 1.5× standard (due to skill levels)
```

**R&D Facilities:**
```
Lab Equipment:
- Basic Workbench: Included (starting equipment)
- CAD Workstation: $15,000 (improves design speed 20%)
- 3D Printer (Prototyping): $25,000 (reduces prototype cost 40%)
- Test Bench: $40,000 (improves testing accuracy, reduces failures)
- Simulation Software: $8,000/year license (predict performance)

Advanced Equipment (Late-Game):
- Dynamometer: $120,000 (precise power/torque testing)
- Emissions Lab: $200,000 (required for EPA certification)
- Materials Lab: $80,000 (analyze metallurgy, composites)
```

**Time Allocation:**
```
R&D Project Timeline (Typical 6-Month Project):

Month 1-2: Concept & Design
- Engineers: 3 full-time
- Activities: CAD modeling, simulations, market research
- Deliverable: Design specification document
- Milestone Payment: None (internal investment)

Month 3-4: Prototyping
- Engineers: 2 full-time (1 transitions to other work)
- Activities: Build prototype, initial testing
- Deliverable: Working prototype
- Cost: $40,000 materials + machining
- Risk: 20% chance prototype fails tests → 1 month delay

Month 5-6: Testing & Refinement
- Engineers: 2 full-time
- Activities: Durability testing, optimization, certification prep
- Deliverable: Production-ready design
- Cost: $15,000 additional testing
- Risk: 10% chance certification fails → 2 month delay + $20k retest

Success Conditions:
✓ All tests passed
✓ Performance meets spec (±5%)
✓ Cost target achieved ($200 BOM target)
✓ Certification obtained

Success Probability:
Base: 60%
+10% if Senior Engineer (Skill >80) leads
+10% if Simulation Software used
+5% if Test Bench available
+5% if similar product developed before
= 90% total (in this example)

Failure Outcomes:
- Partial Failure (30% prob if failed): Delay 2 months, +$50k cost, then succeed
- Complete Failure (10% prob if failed): Scrap project, lose 80% of investment
```

---

### 5.3.2 R&D Project Types

**Type 1: New Product Development**
```
Goal: Create entirely new engine model

Investment: $200k - $500k
Duration: 6-12 months
Engineers: 2-4 full-time
Risk: High (30-40% failure rate)
Reward: 40-50% margins if successful

Example: "EcoEngine Pro" (see In-House section above)
```

**Type 2: Product Variant (Platform Extension)**
```
Goal: Create new variant of existing product

Investment: $80k - $150k
Duration: 3-6 months
Engineers: 1-2 full-time
Risk: Low (10-15% failure rate)
Reward: 30-35% margins

Example:
Base Product: Engine v2 (Standard)
Variant: Engine v2-HP (High-Performance)
Changes: Upgraded pistons, different camshaft, ECU tuning
R&D Cost: $95,000
Result: Sells for +$250 premium, Margin +8%
```

**Type 3: Process Improvement**
```
Goal: Reduce production cost or improve quality

Investment: $30k - $80k
Duration: 2-4 months
Engineers: 1 part-time
Risk: Very Low (5% failure rate)
Reward: 5-15% cost reduction

Example:
Current: Engine v1 BOM cost $180
Project: Optimize casting process, reduce material waste
R&D Cost: $45,000
Result: BOM cost reduced to $165 (-8.3%)
Annual Savings: 10,000 units × $15 = $150,000
Payback: 3.6 months
```

**Type 4: Customer Co-Development**
```
Goal: Jointly develop with customer

Investment: Player pays 30-50% of total
Duration: 4-8 months
Engineers: 1-3 part-time (customer provides rest)
Risk: Medium (15-25% failure, but customer shares loss)
Reward: Shared IP, 25-35% margins

Example: See Co-Development Partner section above
```

---

### 5.3.3 R&D Success Factors

**Skill Match:**
```
Project: High-Performance Electric Motor
Required Expertise: Electrical (primary), Materials (secondary)

Team Assignment:
Engineer_Tom (Electrical, Skill 72): Lead ✓ Good match
Engineer_Lisa (Materials, Skill 68): Support ✓ Good match
Engineer_Sarah (Mechanical, Skill 85): Support ⚠ Skill wasted

Success Probability:
+15% (Lead has right specialization)
+10% (Support has relevant specialization)
-5% (Over-skilled engineer on non-critical path = morale risk)
Net: +20% boost
```

**Equipment & Tools:**
```
Project: Precision Fuel Injection System

Available Equipment:
✓ CAD Workstation: +10% design speed
✓ Simulation Software: +15% success (predict flow dynamics)
✗ Test Bench (Fuel): Not available → Must outsource testing (-$20k, -10% success)

Net Effect: +15% success, -10% efficiency
```

**Experience / Learning Curve:**
```
Similar Projects Completed:
- 0 similar: Base success rate
- 1-2 similar: +10% success (some knowledge transfer)
- 3-5 similar: +20% success (established process)
- 6+ similar: +25% success (mastery)

Example:
Player has developed 4 engine variants previously
New engine variant project: +20% success rate
New hydraulic pump project: +0% (different domain)
```

**Market Research:**
```
Optional: Spend $10k-$30k on market research before R&D

Benefits:
- Identifies customer pain points (target features correctly)
- Estimates demand (production planning)
- Competitive analysis (pricing guidance)

Success Boost:
+10% if market research done (reduces "product-market fit" risk)

Example:
Without Research: Build engine assuming 300 units/month demand
  Reality: Only 150 units/month (overproduction, inventory costs)

With Research: Discover market needs 200 units/month
  Build for 250 capacity (slight buffer)
  Reality: 210 units/month (perfect match!)
```

---

## 5.4 Contract Acquisition & Negotiation

### 5.4.1 Customer Discovery

**Acquisition Channels:**

**Channel 1: Reputation-Based (Passive)**
```
Mechanic:
- High reputation (>80) attracts inquiries automatically
- Customers approach player with offers
- Frequency: 1-2 offers per month (at high reputation)

Example Event:
"📧 New Contract Inquiry from AeroTech Industries
 They heard about your high-quality production from General Motors.
 Interested in co-developing a lightweight engine for drone applications.
 
 Estimated Volume: 400 units/month
 Proposed Margin: 33%
 R&D Split: 50/50
 
 [Review Details] [Decline] [Counter-Offer]"
```

**Channel 2: Active Outreach (Marketing)**
```
Mechanic:
- Player spends $20k-$100k on marketing campaign
- Targets specific industry (automotive, industrial, marine, aerospace)
- Results appear 1-2 months later

Example:
Player invests: $50,000 in trade show booth (Industrial Expo)

Results (probabilistic):
- 3-5 leads generated
- Lead Quality:
  - 40% OEM (low margin, high volume)
  - 40% Co-Dev (medium margin, medium volume)
  - 20% Custom/Premium (high margin, low volume)

Sample Leads:
1. Acme Pumps (OEM): 800 units/mo, 24% margin
2. HydroTech (Co-Dev): 300 units/mo, 31% margin
3. Marine Engines Ltd (Premium): 150 units/mo, 42% margin

Player chooses: Pursue 1-2 leads (limited bandwidth)
```

**Channel 3: Referrals**
```
Mechanic:
- Satisfied customers refer others
- Higher success rate (warm introduction)
- Better contract terms (trust-based)

Trigger:
- Contract completed with >95% quality, on-time delivery
- 25% chance customer refers another

Example:
Completed contract with Startup X (electric motors)
Startup X founder refers player to:
→ Startup Y (same industry, different product)

Referral Bonus:
- +10% to negotiated margin (trust premium)
- Faster decision (1 week vs 4 weeks normal)
- More flexible terms (willing to try new ideas)
```

**Channel 4: Industry Events (Late-Game)**
```
Unlock: Player Level 15+

Mechanic:
- Attend annual industry conference ($30k registration + travel)
- Network with 10-15 potential customers
- Speed-dating style pitches

Mini-Game:
Player presents factory capabilities (30-second pitch)
Customers rate presentation:
- Production capacity shown
- Quality metrics highlighted
- Unique capabilities (MES automation, fast ECO response, etc.)

High-scoring pitches → Follow-up meetings → Contracts

Benefits:
- Multiple leads simultaneously
- High-quality customers (serious buyers at conferences)
- Partnerships (potential co-development)
```

---

### 5.4.2 Negotiation Mechanics

**Negotiation Screen UI:**
```
┌─ CONTRACT NEGOTIATION: AeroTech Industries ───────────┐
│                                                        │
│ Product: Drone Engine (Custom Design)                 │
│ Estimated Volume: 400 units/month                     │
│                                                        │
│ ──── NEGOTIABLE TERMS ────                            │
│                                                        │
│ Payment Per Unit:                                      │
│   Their Offer: $580   [──●────────] $720  Your Ask    │
│   Current: $650 (Compromise)                           │
│                                                        │
│ Margin:                                                │
│   Calculated: 31% (based on $650 pricing)             │
│   ⚠ Your minimum: 25% (below this = reject)           │
│                                                        │
│ Volume Commitment:                                     │
│   Their Offer: 300   [─────●─────] 500  Your Ask      │
│   Current: 400 units/month                             │
│   Note: Higher volume = lower per-unit risk            │
│                                                        │
│ Contract Duration:                                     │
│   Their Offer: 12 months [──●────] 36 months Your Ask │
│   Current: 24 months                                   │
│   Trade-off: Longer = stability, Shorter = flexibility│
│                                                        │
│ Quality Requirements:                                  │
│   Their Demand: <0.5% defect rate (strict)            │
│   Industry Standard: <2%                               │
│   Can negotiate: [Try to negotiate to 1%] or [Accept] │
│                                                        │
│ R&D Investment Split:                                  │
│   Their Offer: 50/50  [───●──────] 70/30  Your Ask    │
│   Current: 60/40 (they pay 60%)                        │
│   Your Investment: $80,000                             │
│                                                        │
│ IP Ownership:                                          │
│   ○ Exclusive to AeroTech (they own 100%)             │
│   ● Joint Ownership 50/50 (can sell to others Y2+)    │
│   ○ Player Ownership 100% (higher R&D cost)           │
│                                                        │
│ Penalties/Bonuses:                                     │
│   Late Delivery: -$1,500/day (negotiable)             │
│   Defect Penalty: -$400/unit (negotiable)             │
│   Zero-Defect Bonus: +$20,000/quarter (optional)      │
│                                                        │
│ ──── DEAL SUMMARY ────                                │
│ Estimated Annual Revenue: $3.12M                       │
│ Estimated Annual Profit: $967k                         │
│ R&D Investment: $80k (payback: 1 month)               │
│ Risk Level: MEDIUM (new customer, drone market)       │
│                                                        │
│ Their Satisfaction: 😐 Neutral (65/100)               │
│ Likelihood to Accept: 70%                              │
│                                                        │
│ [Send Counter-Offer] [Accept Deal] [Walk Away]        │
└────────────────────────────────────────────────────────┘
```

**Negotiation Dynamics:**

**Player Leverage:**
```
Factors that increase player negotiating power:

✓ High Reputation (>85): +15% to all asks
✓ Unique Capability: +10% (e.g., ultra-fast ECO response via MES)
✓ Multiple Competing Offers: +20% (can walk away easily)
✓ Referral: +10% (trust-based relationship)
✓ Industry Award/Certification: +5% (ISO 9001, etc.)

Example:
Base position: 50/50 negotiation
With Reputation 90 + Unique MES: 65/35 in player's favor
→ Can demand $680 instead of $650 (+4.6% revenue)
```

**Customer Leverage:**
```
Factors that increase customer negotiating power:

⚠ Player Needs Cash: -15% (desperate for work)
⚠ Customer is Large (Fortune 500): -10% (prestigious, but demanding)
⚠ Commodity Product: -15% (customer has many alternatives)
⚠ Player Capacity Underutilized: -10% (visible desperation)

Example:
Player at 40% capacity utilization, needs revenue
Customer knows this (visible on industry reports)
→ Customer demands $600 instead of $650 (-7.7% revenue)
→ Player may need to accept to fill capacity
```

**Win-Win Outcomes:**
```
Optimal Negotiation Strategy:
Find terms where both sides benefit

Example:
Customer wants: Lower price ($600)
Player wants: Longer contract (36 months)

Compromise:
- Price: $620 (split difference)
- Duration: 36 months (player gets stability)
- Volume: 450 units/month (customer gets scale discount)
- Result: Both sides rate 75/100 satisfaction → Deal accepted!

Relationship Bonus:
- Customer likely to renew (long relationship)
- Referrals more likely (satisfied customer)
- Flexible on ECOs (trust built)
```

---

### 5.4.3 Contract Management Dashboard

**Active Contracts View:**
```
┌─ CONTRACT PORTFOLIO ──────────────────────────────────┐
│                                                        │
│ Contract         Customer    Vol/Mo  Progress  Status │
│ GM-Standard      General     1,000   █████░░   On Track│
│ GreenDrive-EV    GreenDrive    200   ███░░░░   At Risk│
│ IPC-Pump         IPC Corp      500   ██████░   Ahead  │
│ AeroTech-Drone   AeroTech      400   ████░░░   On Track│
│                                                        │
│ Total Monthly Volume: 2,100 units                      │
│ Total Monthly Revenue: $1.47M                          │
│ Weighted Avg Margin: 29.3%                             │
│                                                        │
│ ──── RISK DASHBOARD ────                              │
│ ⚠ GreenDrive-EV: Behind schedule (5 days)             │
│   Issue: ECO delays (v2.1 → v2.2 transition)          │
│   Action: Allocate overtime? [Yes] [No]                │
│                                                        │
│ ✓ IPC-Pump: 2 weeks ahead of schedule                 │
│   Opportunity: Propose early delivery bonus?          │
│                                                        │
│ ──── UPCOMING RENEWALS ────                           │
│ GM-Standard: Renews in 3 months                        │
│   Likely to renew? 85% (good performance history)     │
│   Opportunity: Negotiate +5% price increase?          │
│                                                        │
│ [Detailed View] [Capacity Planning] [Profitability]   │
└────────────────────────────────────────────────────────┘
```

---

## 5.5 Contract Execution & Performance

### 5.5.1 Delivery Mechanics

**Weekly Delivery Cycle:**
```
Contract: GM-Standard (1,000 units/month ≈ 250/week)

Week 1:
- Production Target: 250 units
- Actual Production: 248 units (99.2%)
- Quality: 2 defects (0.8% rate) ✓ Within spec (<1%)
- Delivery Status: ON TIME ✓

MES Alert:
"Production slightly behind target (248/250)
 Recommend: +2 hours overtime to catch up
 Cost: $180 overtime pay
 Benefit: Maintain buffer for Week 2"

Player Decision: [Approve Overtime] [Accept Slight Shortage]
```

**Monthly Performance Review:**
```
Contract: GM-Standard
Month: December 2025

Performance Summary:
│ Metric              │ Target  │ Actual │ Status │ Impact    │
│────────────────────│─────────│────────│────────│───────────│
│ Volume Delivered    │ 1,000   │ 994    │ ⚠      │ -$2,700   │
│ Defect Rate         │ <1.0%   │ 0.6%   │ ✓      │ +$0       │
│ On-Time Delivery    │ 100%    │ 96%    │ ⚠      │ -$3,000   │
│ Zero-Defect Weeks   │ Bonus   │ 2/4    │ ○      │ +$0       │
│────────────────────│─────────│────────│────────│───────────│
│ Base Revenue        │         │        │        │ $450,000  │
│ Volume Penalty      │         │        │        │ -$2,700   │
│ Late Penalty        │         │        │        │ -$3,000   │
│ Net Revenue         │         │        │        │ $444,300  │
│                    │         │        │        │ (-1.3%)   │

Customer Satisfaction: 78/100 (Acceptable)
Renewal Likelihood: 75% → 70% (declining trend)

Feedback:
"Delivery reliability needs improvement. Consider expanding capacity
 or implementing better production planning."

Action Items:
⚠ Investigate bottlenecks (Week 2 delay)
⚠ Review MES scheduling rules
💡 Consider adding 2nd shift or AGV investment
```

---

### 5.5.2 Customer Relationship System

**Satisfaction Factors:**
```
Customer Satisfaction Score (0-100):

Positive Factors:
+30: On-time delivery (100% on schedule)
+25: Quality (zero defects or <0.5% consistently)
+15: Responsiveness (fast ECO implementation)
+10: Communication (proactive updates on issues)
+10: Flexibility (accommodate rush orders)
+10: Innovation (suggest improvements)

Negative Factors:
-40: Late deliveries (consistent pattern)
-30: Quality issues (>3% defect rate)
-20: Poor communication (no visibility)
-15: Inflexibility (refuse reasonable requests)
-10: Price increases (unexpected cost hikes)

Example Calculation:
GM-Standard (December 2025):
+28: On-time 96% of month (not perfect)
+25: Quality excellent (0.6%)
+10: Responsive to their ECO request
+5: Communication acceptable (not proactive)
+0: No special flexibility shown
+10: Suggested BOM cost reduction (innovation)
= 78/100 (Acceptable, room for improvement)
```

**Relationship Tiers:**
```
Score 90-100: PLATINUM (Best Customer)
- Benefits:
  - +10% pricing power (can charge premium)
  - Priority on new product opportunities
  - Flexible terms (payment, delivery)
  - Referrals to sister companies
  - Long-term contracts (3+ years)
  
Score 75-89: GOLD (Good Customer)
- Benefits:
  - Standard pricing
  - Contract renewal likely (80%+)
  - Moderate flexibility
  - Occasional referrals

Score 60-74: SILVER (Acceptable)
- Benefits:
  - Competitive pricing pressure
  - Contract renewal uncertain (50-60%)
  - Limited flexibility
  - At-risk if competitor offers better terms

Score Below 60: AT RISK
- Warning signs:
  - Contract unlikely to renew (<40%)
  - Customer seeking alternative suppliers
  - Increased scrutiny (audits, complaints)
  - Price renegotiation demanded

Example:
GM-Standard at 78/100 (GOLD tier)
→ Likely to renew next year
→ But trending down (was 85 last quarter)
→ Action: Investigate root causes, improve delivery
```

---

## 5.6 Integration with Other Systems

### 5.6.1 R&D → PLM → Production Pipeline

**Complete Flow Example:**
```
PHASE 1: R&D (Months 1-6)
─────────────────────────────
Engineers develop: Engine v3 (High-Performance)
Deliverables:
- CAD models
- BOM (Bill of Materials)
- Process routing (machining, assembly steps)
- Quality specifications
- Cost target: $280 BOM

Output: Product definition ready for PLM

PHASE 2: PLM Setup (Month 7)
─────────────────────────────
PLM team (player) creates:
- Part master data (300+ components)
- Routing operations (15 steps)
- Work instructions (assembly sequences)
- NC programs (CNC/Lathe G-code)
- QC plans (inspection points)

Output: Production-ready data

PHASE 3: MES Integration (Month 7-8)
─────────────────────────────────────
MES team (player) configures:
- Machine recipes (torque, speed, feed by part)
- Auto-routing rules (v3 requires advanced QC)
- Worker assignments (need Assembly Level 3 cert)
- Quality sampling (20% for first 100 units)

Output: MES ready to execute

PHASE 4: Production Ramp (Months 8-10)
───────────────────────────────────────
Pilot Production:
- Week 1-2: 10 units/week (learning curve)
- Week 3-4: 25 units/week (debugging issues)
- Week 5-8: 50 units/week (stabilizing)
- Week 9+: 100 units/week (full rate)

Issues Found:
- Torque spec too tight (5% scrap)
  → ECO-001: Relax tolerance 85±1 → 85±2Nm
- Assembly sequence suboptimal (12 min → 10 min possible)
  → Update work instructions

Output: Stable production at target rate

PHASE 5: Contract Delivery (Month 11+)
───────────────────────────────────────
Customer: Automotive OEM
Volume: 400 units/month
Revenue: $1,200/unit = $480k/month
Margin: 38%
Performance: 99.5% on-time, 0.8% defects

Result: Successful R&D → Production transition!
```

---

### 5.6.2 Contracts → Planning → Capacity

**Capacity Planning Driven by Contracts:**
```
Active Contracts:
1. GM-Standard: 1,000 units/mo, 12 min/unit cycle → 200 hours/mo
2. GreenDrive-EV: 200 units/mo, 15 min/unit → 50 hours/mo
3. IPC-Pump: 500 units/mo, 10 min/unit → 83 hours/mo
4. AeroTech-Drone: 400 units/mo, 18 min/unit → 120 hours/mo

Total Required: 453 hours/month

Available Capacity:
- CNC_01: 160 hours/mo (single shift)
- CNC_02: 160 hours/mo
- CNC_03: 160 hours/mo
Total: 480 hours/mo

Utilization: 453 / 480 = 94.4% ⚠ High!

MES Recommendation:
"Capacity utilization >90% is risky
 Consider:
 A) Add 2nd shift on 1 CNC (+160 hours) → 70% utilization
 B) Purchase CNC_04 (+160 hours) → 71% utilization
 C) Decline new contracts until existing complete"

Player Decision:
→ Choose B (purchase CNC_04 for $38k)
→ Reason: 2nd shift increases labor cost 15%, capex cheaper long-term
→ New utilization: 70.8% (healthy buffer for growth)
```

---

## 5.7 Progression & Unlocks

**Contract Access by Level:**
```
Levels 1-5:
- Simple OEM contracts only
- Volume: 100-500 units/month
- Margin: 18-24%
- Example: "Basic Engine Production for Local Manufacturer"

Levels 6-10:
- Medium OEM contracts
- First co-development opportunities
- Volume: 500-1,500 units/month
- Margin: 22-30%
- Example: "Co-Develop Pump Motor with IPC"

Levels 11-15:
- Advanced OEM contracts
- Multiple co-development projects
- First in-house R&D allowed
- Volume: 1,000-3,000 units/month total
- Margin: 25-35%

Levels 16-20:
- Startup/boutique customers unlocked
- Complex co-development
- In-house product portfolio (2-3 products)
- Volume: 2,000-5,000 units/month total
- Margin: 28-42%

Levels 21-25 (Endgame):
- Enterprise contracts (Fortune 500)
- Global customers
- Full in-house product line
- Multiple industries (automotive, industrial, aerospace)
- Volume: 5,000-15,000 units/month total
- Margin: 30-50% (diversified portfolio)
```

**R&D Unlocks:**
```
Level 1-5:
- Can modify existing products (ECOs)
- Cannot develop new products

Level 6-10:
- Can develop product variants (platform extensions)
- R&D team size: max 2 engineers

Level 11-15:
- Can develop entirely new products (co-development or in-house)
- R&D team size: max 4 engineers
- Access to advanced simulation tools

Level 16-20:
- Can develop across multiple domains
- R&D team size: max 8 engineers
- Access to testing labs (emissions, durability)

Level 21-25:
- Can develop breakthrough technologies
- R&D team size: unlimited
- Access to research partnerships (universities)
```

---

## 5.8 Functional Gameplay Examples

### Example 1: Early-Game OEM Contract (Level 3)

**Scenario:**
```
Player: New factory, 2 CNC machines, 3 workers
Contract Offer: "Basic Engine Production - 300 units/month"
Customer: Regional Manufacturer (low-risk)
Payment: $420/unit
Estimated Margin: 21% (after $330 BOM cost)
Duration: 12 months

Player Considerations:
✓ Low risk (proven product, stable customer)
✓ Fills 60% of capacity (good utilization)
✓ Positive cash flow ($26,460/month profit)
✗ Low margin (but acceptable for early game)

Decision: ACCEPT
Outcome:
- Stable revenue for 12 months
- Learn production basics
- Build reputation (foundation for future)
- Save profits to invest in R&D capability
```

---

### Example 2: Mid-Game Co-Development (Level 12)

**Scenario:**
```
Player: Established factory, 6 machines, 8 workers, 2 R&D engineers
Contract Offer: "Co-Develop Industrial Pump Motor"
Customer: IPC (medium-risk, growing company)
Investment: $95,000 (R&D), 5 months duration
Revenue: $680/unit, 500 units/month = $340k/month
Margin: 31%
Duration: 24 months

Player Considerations:
✓ Medium margin (profitable)
✓ Shared R&D cost (lower financial risk)
✓ IP ownership (can sell to others in Year 2)
✓ Strategic partnership (diversification into pumps)
✗ R&D investment required ($95k upfront)
✗ Coordination overhead (joint decision-making)

Decision: ACCEPT
Outcome:
- R&D completed successfully (Month 5)
- Production ramps Month 6-8
- Revenue $340k/month starting Month 9
- Payback on R&D: ~3 months
- Year 2: Sell to 2 additional pump manufacturers
  → Additional $180k/month revenue (90% margin, shared IP)
- Total ROI: 320% over 24 months
```

---

### Example 3: Late-Game In-House Product (Level 18)

**Scenario:**
```
Player: Large factory, 15 machines, 20 workers, 5 R&D engineers
Project: "EcoEngine Pro" (Fuel-Efficient Proprietary Engine)
Investment: $340,000 (R&D, prototyping, certification)
Duration: 9 months R&D + 3 months ramp
Target Market: Small manufacturers, retrofit market
Pricing: $850/unit
Estimated Volume: 300 units/month → 800/month (Year 2)
Margin: 45%

Player Considerations:
✓ Maximum margin (full ownership)
✓ Strategic asset (valuable IP)
✓ Scalability (sell to many customers)
✓ Market demand validated (research shows need)
✗ High upfront investment ($340k)
✗ Market risk (might not sell well)
✗ Long payback (6-9 months if successful)

Decision: ACCEPT (calculated risk)
Outcome:
- R&D success after 9 months
- Pilot production Month 10-12
- Market launch Month 13
- Sales: 200 units/month initially (below target)
- Marketing campaign (+$50k) Month 14
- Sales increase: 350 units/month Month 15-18
- Sales mature: 650 units/month Month 19-24
- Total Revenue Year 1: $4.08M
- Total Profit Year 1: $1.84M (after all costs)
- ROI: 441% over 2 years
- Player learns: In-house products are risky but highly rewarding!
```

---

**End of Section 5 - R&D & Customer Contracts**

Next: Section 6 (Planning & Capacity Management) with advanced scheduling...

---

# 6. PLANNING & CAPACITY MANAGEMENT

## 6.1 Overview & Strategic Importance

**Planning & Capacity Management** is the **operational strategy layer** that connects customer contracts (Section 5) to shop-floor execution (Sections 2-3). Players must allocate finite resources (machines, workers, time) to meet multiple competing demands efficiently.

**Core Challenge:**  
"You have 3 machines, 5 workers, and 4 contracts due this week. How do you sequence production to maximize on-time delivery, minimize overtime, and prevent bottlenecks?"

**Key Design Principles:**
- **Resource Constraints are Real:** Cannot do everything simultaneously
- **Trade-offs are Constant:** Speed vs. Quality, Volume vs. Flexibility
- **Optimization Rewarded:** Good planning = 20-30% efficiency improvement
- **Multiple Valid Strategies:** FIFO, Priority, Lean, Hybrid all viable

---

## 6.2 Production Planning Fundamentals

### 6.2.1 Planning Hierarchy

```
LEVEL 1: Strategic (Monthly-Quarterly)
├─ Contract portfolio decisions
├─ Capacity expansion planning (new machines)
├─ Workforce planning (hiring, training)
└─ R&D project scheduling

LEVEL 2: Tactical (Weekly)
├─ Work order sequencing
├─ Shift assignments
├─ Material procurement timing
└─ Maintenance windows

LEVEL 3: Operational (Daily)
├─ Line-by-line schedules
├─ Worker-to-machine assignments
├─ Priority adjustments (rush orders)
└─ Real-time problem-solving
```

**Player Interaction:**
- **Casual:** Auto-scheduler handles Levels 2-3
- **Strategic:** Player sets Level 2, auto Level 3
- **Expert:** Full manual control all levels

---

### 6.2.2 Capacity Calculation (Detailed)

**Machine Capacity:**
```
Single Machine Monthly Capacity:

Available Time:
- Calendar hours: 30 days × 24 hours = 720 hours
- Minus planned downtime:
  - Weekends (if single-shift): 8 Saturdays+Sundays × 8hr = 64 hours
  - Breaks: 30 days × 1 hour = 30 hours
  - Shift changes: 30 days × 0.25 hour = 7.5 hours
  - Planned maintenance: 4 hours/month

Net Available: 720 - 64 - 30 - 7.5 - 4 = 614.5 hours/month

Effective Capacity:
- OEE adjustment: 614.5 × 0.78 (typical OEE) = 479 effective hours

Production Capacity:
- If cycle time = 12 min/part (0.2 hours)
- Monthly output: 479 / 0.2 = 2,395 parts/month (single-shift)

Multi-Shift:
- 2 shifts: 2,395 × 1.9 = 4,550 parts/month (90% efficiency 2nd shift)
- 3 shifts: 2,395 × 2.7 = 6,465 parts/month (80% efficiency 3rd shift)

Example (3-Machine Factory):
CNC_01: 2,395 parts/month (single-shift)
CNC_02: 2,395 parts/month (single-shift)  
CNC_03: 4,550 parts/month (double-shift)
Total: 9,340 parts/month CNC capacity
```

**Multi-Product Capacity:**
```
Problem: Different products use different cycle times

Contract Mix:
- Product A: 1,000 units/mo × 10 min = 167 hours
- Product B: 800 units/mo × 15 min = 200 hours
- Product C: 400 units/mo × 20 min = 133 hours
Total Required: 500 hours

Available: 479 hours (single CNC, single shift)
Result: OVERLOADED by 21 hours (4.4%)

Options:
1. Add overtime: 21 hours × $50/hour = $1,050/month
2. Add 2nd shift: +479 hours capacity (overkill, underutilized)
3. Reject Product C contract (lowest margin)
4. Negotiate staggered delivery (spread load)

Player Decision Required!
```

---

### 6.2.3 Demand vs. Capacity Visualization

**Capacity Planning Chart (In-Game UI):**
```
┌─ CAPACITY ANALYSIS - Month: January 2026 ────────────┐
│                                                        │
│ CNC Machining Capacity (hours):                       │
│                                                        │
│ 600├──────────────────────────────────────────────────│
│    │                                                   │
│ 500├───────────────────■ Demand (520h) OVER CAPACITY │
│    │                   ││                              │
│ 400├─────────────────  ││  ──────────────────────────│
│    │                   ││                              │
│ 300├─────────────────  ││  ──────────────────────────│
│    │                   ││                              │
│ 200├─────────────────  ││  ──────────────────────────│
│    │                   ││                              │
│ 100├─────────────────  ││  ──────────────────────────│
│    │ ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓││  Available (479h)           │
│   0└───────────────────▼▼──────────────────────────────│
│                                                        │
│ ⚠ CAPACITY SHORTFALL: 41 hours (8.6%)                │
│                                                        │
│ Impact:                                                │
│ • Late deliveries: 15-20% of orders                    │
│ • Overtime cost: $2,050/month (if compensated)        │
│ • Customer satisfaction: -12 points                    │
│                                                        │
│ Recommendations:                                       │
│ 1. Add 2nd shift to CNC_02 → Solves shortfall         │
│    Cost: $12,000/month (labor), Benefit: $18,000 (avoid penalties)│
│ 2. Purchase CNC_04 → Long-term solution               │
│    Cost: $38,000 capex, $800/month operating          │
│ 3. Reject lowest-margin contract (AeroTech)           │
│    Loss: $8,000/month revenue, Gain: capacity buffer  │
│                                                        │
│ [View Detailed Breakdown] [Run Scenario] [Decide]     │
└────────────────────────────────────────────────────────┘
```

---

## 6.3 Scheduling Strategies

### 6.3.1 First-In-First-Out (FIFO)

**Algorithm:**
```
Sort work orders by arrival time
Process oldest first

Pseudocode:
WorkOrders = [WO1_arrived_Jan1, WO2_arrived_Jan3, WO3_arrived_Jan2]
Sorted = [WO1, WO3, WO2]  // Chronological
FOR EACH wo IN Sorted:
  Assign to first available machine
  Execute until complete
  Move to next
END
```

**Pros:**
- ✓ Simple (no complex logic)
- ✓ Fair (no starvation)
- ✓ Predictable (customers know wait time)

**Cons:**
- ✗ Ignores urgency (late orders not prioritized)
- ✗ Ignores job size (large jobs block small ones)
- ✗ Suboptimal throughput

**Use Case:** Low-variety production, all contracts equal priority

---

### 6.3.2 Shortest Processing Time (SPT)

**Algorithm:**
```
Sort work orders by duration (shortest first)
Process quick jobs first

Example:
WO_A: 100 parts × 15 min = 25 hours
WO_B: 50 parts × 10 min = 8.3 hours
WO_C: 200 parts × 12 min = 40 hours

Sequence: B → A → C

Result:
- Job B complete: 8.3 hours (1 customer happy fast)
- Job A complete: 33.3 hours (2 customers served)
- Job C complete: 73.3 hours (all done)

Average wait: (8.3 + 33.3 + 73.3) / 3 = 38.3 hours

Compare to FIFO (A→B→C):
- Job A complete: 25 hours
- Job B complete: 33.3 hours
- Job C complete: 73.3 hours
Average wait: 43.9 hours

SPT is 13% faster average!
```

**Pros:**
- ✓ Maximizes throughput (more jobs/time)
- ✓ Reduces average wait time
- ✓ Good for high-mix, low-volume

**Cons:**
- ✗ Large jobs can wait forever (starvation)
- ✗ Ignores deadlines
- ✗ Frustrates customers with big orders

**Use Case:** Job shop, many small orders, no hard deadlines

**Mitigation:** Hybrid approach (SPT but force large jobs every X cycles)

---

### 6.3.3 Earliest Due Date (EDD)

**Algorithm:**
```
Sort work orders by deadline (earliest first)
Process most urgent first

Example:
WO_A: Due in 10 days
WO_B: Due in 5 days
WO_C: Due in 15 days

Sequence: B → A → C

Result:
- All deadlines met (if capacity exists)
- Penalties avoided
```

**Pros:**
- ✓ Minimizes late deliveries
- ✓ Customer satisfaction (meets expectations)
- ✓ Penalty avoidance (financial benefit)

**Cons:**
- ✗ May sacrifice throughput
- ✗ Doesn't account for processing time
- ✗ Can create bottlenecks if job sizes vary

**Use Case:** Contract-heavy factories, penalty-sensitive business

---

### 6.3.4 Critical Ratio (CR)

**Algorithm:**
```
Critical Ratio = (Due Date - Today) / Processing Time Remaining

Sort by CR (lowest = most urgent)

Example:
Today: Day 0
WO_A: Due Day 10, Processing 5 days → CR = 10/5 = 2.0
WO_B: Due Day 8, Processing 6 days → CR = 8/6 = 1.33 (CRITICAL!)
WO_C: Due Day 20, Processing 4 days → CR = 20/4 = 5.0

Sequence: B (1.33) → A (2.0) → C (5.0)

Rationale:
- WO_B: Only 1.33× buffer → risk of late
- WO_A: 2× buffer → safe for now
- WO_C: 5× buffer → very safe
```

**Pros:**
- ✓ Dynamic urgency (updates daily as time passes)
- ✓ Balances deadline AND duration
- ✓ Optimal for complex scheduling

**Cons:**
- ✗ Requires accurate time estimates
- ✗ More complex to understand
- ✗ Can fluctuate (priorities change)

**Use Case:** Multi-contract factories with varying deadlines

**Advanced:** MES can auto-reschedule daily based on updated CRs

---

### 6.3.5 Hybrid Strategy (Player-Configurable)

**Example MES Rule:**
```
IF AnyContract.DaysUntilDue < 3 THEN
  Scheduler = "EDD"  // Crisis mode, prioritize deadlines
ELSE IF TotalBacklog > 50 THEN
  Scheduler = "SPT"  // Clear backlog fast
ELSE IF CustomerSatisfaction_Average < 70 THEN
  Scheduler = "CR"   // Balance all factors
ELSE
  Scheduler = "FIFO" // Stable, predictable
END

Player can customize thresholds:
- DaysUntilDue threshold: [1-7 days]
- Backlog threshold: [20-100 parts]
- Satisfaction threshold: [50-90]
```

---

## 6.4 Shift Management

### 6.4.1 Shift Structures

**Single Shift (8 hours/day, 5 days/week):**
```
Schedule: Monday-Friday, 8:00 AM - 4:00 PM
Coverage: 40 hours/week = 160 hours/month
Cost: Base labor rate ($18-$25/hour avg)
Utilization: 60-70% (lower due to single coverage)

Pros:
- ✓ Lowest labor cost
- ✓ Easier management
- ✓ Better worker morale (normal hours)

Cons:
- ✗ Limited capacity
- ✗ Machine idle 16 hours/day
- ✗ Cannot handle urgent/rush orders well
```

**Double Shift (16 hours/day):**
```
Schedule:
- Shift 1: 6:00 AM - 2:00 PM
- Shift 2: 2:00 PM - 10:00 PM
Coverage: 80 hours/week = 320 hours/month
Cost: Base + 10-15% shift differential (night premium)
Utilization: 75-85%

Pros:
- ✓ 2× capacity
- ✓ Better machine utilization
- ✓ Can handle higher volume

Cons:
- ✗ +12-17% labor cost (shift differential)
- ✗ Coordination overhead (shift handoffs)
- ✗ Worker fatigue (2nd shift often less efficient)
```

**Triple Shift (24/7):**
```
Schedule:
- Shift 1: 6:00 AM - 2:00 PM
- Shift 2: 2:00 PM - 10:00 PM
- Shift 3: 10:00 PM - 6:00 AM
Coverage: 168 hours/week = 672 hours/month
Cost: Base + 15% (2nd) + 25% (3rd) shift differential
Utilization: 80-90%

Pros:
- ✓ Maximum capacity
- ✓ Continuous production (automotive-style)
- ✓ Can meet extreme demand

Cons:
- ✗ +18-22% labor cost overall
- ✗ High fatigue (3rd shift 70-80% efficient)
- ✗ Maintenance challenges (must schedule carefully)
- ✗ Harder to recruit (night shift unpopular)
```

### 6.4.2 Shift Assignment Optimization

**Worker-to-Shift Matching:**
```
Workers have preferences:
- Worker_Sarah: Prefers Day (morale +10 if assigned)
- Worker_Mike: Prefers Evening (morale +5)
- Worker_Carlos: Indifferent (morale ±0)

Skill Considerations:
- Shift 1 (Day): Most skilled workers (complex jobs)
- Shift 2 (Evening): Mixed skill (routine + some complex)
- Shift 3 (Night): Routine jobs only (less supervision)

Example Assignment:
Shift 1:
- Worker_Sarah (Skill 95, Machining Expert): CNC_02 ✓
- Worker_Lisa (Skill 82, QC Expert): QC_01 ✓
- Worker_Tom (Skill 75, Assembly): Assembly_03 ✓

Shift 2:
- Worker_Mike (Skill 78, Machining): CNC_01 ✓
- Worker_Carlos (Skill 70, Assembly): Assembly_01 ✓
- Worker_Jane (Skill 68, QC): QC_02 ✓

Result:
- Day shift: High-complexity work (v3 engines)
- Evening shift: Standard work (v1/v2 engines)
- Morale: +8 avg (preference matching)
- Efficiency: 92% day, 87% evening
```

---

## 6.5 Line Balancing & Bottleneck Management

### 6.5.1 Identifying Bottlenecks

**Theory of Constraints (TOC):**
```
Bottleneck = Station with lowest capacity in line

Example Line:
Station A (Lathe): 5 min/part = 12 parts/hour
Station B (CNC): 8 min/part = 7.5 parts/hour ← BOTTLENECK
Station C (Assembly): 6 min/part = 10 parts/hour

Line Throughput: Limited by Station B = 7.5 parts/hour

Buffer Analysis:
- Buffer before Station B: Accumulates (Lathe faster than CNC)
- Buffer after Station B: Empty (Assembly waiting for CNC)

Visual Indicator (In-Game):
Station B highlighted RED (bottleneck)
Buffer_B: 85% full ⚠
```

**MES Bottleneck Detection:**
```
MES monitors:
- Station utilization %
- Buffer occupancy
- Idle time per station

Algorithm:
FOR EACH station IN line:
  IF utilization > 95% AND buffer_before > 75%:
    Flag as bottleneck
  END
END

Alert:
"⚠ Bottleneck detected: CNC_02
 Utilization: 97%
 Upstream buffer: 82% (parts waiting)
 Downstream idle: 23% (Assembly waiting)
 
 Recommendations:
 1. Add 2nd CNC (parallel processing) → +100% capacity
 2. Reduce upstream speed (balance line) → minimize WIP
 3. Upgrade CNC_02 (faster machine) → +30% speed
 
 [Analyze] [Implement Solution]"
```

---

### 6.5.2 Line Balancing Strategies

**Strategy 1: Add Parallel Capacity**
```
Before:
Lathe → CNC (bottleneck) → Assembly
        7.5 parts/hr

After:
        ┌─ CNC_01 (7.5 parts/hr) ─┐
Lathe ──┤                          ├─ Assembly
        └─ CNC_02 (7.5 parts/hr) ─┘
Combined: 15 parts/hr

Result:
- Line throughput: 12 parts/hr (now limited by Lathe)
- CNC no longer bottleneck!
- New bottleneck: Lathe (but improved overall)

Cost: $38,000 (CNC_02 purchase)
Benefit: +60% throughput (7.5 → 12 parts/hr)
Payback: If margin $100/part, +4.5 parts/hr × 160 hr/mo = +$72k/mo
Payback period: 0.5 months (excellent ROI!)
```

**Strategy 2: Balance Line Speed**
```
Option: Slow down upstream to match bottleneck

Before:
Lathe (12 parts/hr) → CNC (7.5) → Assembly (10)
WIP accumulation: 4.5 parts/hr in buffer

After:
Lathe (7.5 parts/hr, intentionally slowed) → CNC (7.5) → Assembly (7.5)
WIP stable: zero accumulation

MES Implementation:
SET Lathe.FeedRate = Lathe.FeedRate × (CNC_Capacity / Lathe_Capacity)
  = FeedRate × (7.5 / 12) = 62.5% of max speed

Benefits:
- ✓ Lower WIP (less cash tied up)
- ✓ Less material waste (overproduction eliminated)
- ✓ Easier to manage (smooth flow)

Cons:
- ✗ Underutilizes Lathe (only 62.5% capacity)
- ✗ Lower throughput (7.5 vs potential 12 if CNC fixed)

When to use:
- WIP cost > bottleneck fix cost
- Lean/JIT philosophy (minimize inventory)
- Demand matches bottleneck rate (no need for more capacity)
```

**Strategy 3: Selective Routing (Multi-Line)**
```
Use fast products on fast lines, slow on slow lines

Line 1 (Fast):
Lathe_1 (fast) → CNC_1 (fast) → Assembly_1 (fast)
Assigned: Product A (10 min cycle)

Line 2 (Slow/Constrained):
Lathe_2 (fast) → CNC_2 (bottleneck) → Assembly_2 (fast)
Assigned: Product B (15 min cycle, matches CNC_2 constraint)

Result:
- Line 1 runs at full speed (no bottleneck)
- Line 2 accepts slower cycle (product B naturally slow anyway)
- Overall: better utilization, less frustration

MES Rule:
IF Product.CycleTime > 12 min THEN
  Route to Line_2 (bottleneck-friendly)
ELSE
  Route to Line_1 (fast line)
END
```

---

### 6.5.3 Buffer Management

**Buffer Sizing:**
```
Formula:
OptimalBufferSize = (Upstream_Rate - Downstream_Rate) × Time_To_Fix_Bottleneck

Example:
Lathe: 12 parts/hr
CNC: 7.5 parts/hr
Accumulation: 4.5 parts/hr
Time to add 2nd CNC: 2 weeks (planning + delivery)

Buffer needed: 4.5 parts/hr × 320 hours (2 weeks) = 1,440 parts!

Reality Check:
- 1,440 parts × $200 WIP cost/part = $288k tied up
- Too expensive!

Alternative:
1. Smaller buffer (200 parts) + slow upstream to match
   OR
2. Rush CNC purchase (1 week) → buffer 720 parts
   OR
3. Reject new contracts until CNC arrives
```

**Dynamic Buffer Control (MES):**
```
MES monitors buffer in real-time

IF Buffer_B.Occupancy > 80% THEN
  // Bottleneck forming
  Lathe.FeedRate = Lathe.FeedRate × 0.9  // Slow upstream 10%
  Alert("Buffer B filling, upstream slowed")
ELSE IF Buffer_B.Occupancy < 20% THEN
  // Bottleneck resolved
  Lathe.FeedRate = Lathe.BaseSpeed  // Restore speed
  Log("Buffer B normalized, upstream restored")
END

Result:
- Buffer stays 30-60% occupied (optimal)
- Upstream adjusts automatically
- Player doesn't need to micromanage
```

---

## 6.6 Multi-Line Production Planning

### 6.6.1 Line Assignment Strategies

**Dedicated Lines:**
```
Concept: Each line produces one product exclusively

Line 1: Engine v1 only (1,000 units/month)
Line 2: Engine v2 only (800 units/month)
Line 3: Engine v3 only (400 units/month)

Pros:
- ✓ No changeover time
- ✓ Worker specialization (experts on one product)
- ✓ Optimal machine setup (no adjustments)

Cons:
- ✗ Inflexible (cannot reallocate if demand shifts)
- ✗ Underutilization (if v3 demand drops, Line 3 idle)
- ✗ Requires minimum volume per product
```

**Flexible Lines:**
```
Concept: Lines can produce any product (via MES)

Line 1-3: All produce v1/v2/v3 as needed

Allocation (Weekly):
Week 1:
- Line 1: 60% v1, 40% v2
- Line 2: 100% v2
- Line 3: 50% v3, 50% v1

Week 2 (demand changed):
- Line 1: 80% v1, 20% v3
- Line 2: 100% v2
- Line 3: 100% v3

Pros:
- ✓ Maximum flexibility
- ✓ Can respond to demand fluctuations
- ✓ Better capacity utilization

Cons:
- ✗ Changeover time (even if minimal with MES)
- ✗ Worker cross-training required
- ✗ More complex scheduling

Requires: MES auto-configuration (Section 3)
```

**Hybrid Approach (Recommended):**
```
Primary assignment + flex capacity

Line 1: Dedicated to v1 (primary), can produce v2 (backup)
Line 2: Dedicated to v2 (primary), can produce v1/v3 (backup)
Line 3: Flex line (produces v3 or overflow from v1/v2)

Decision Logic:
1. Allocate products to primary lines first
2. Overflow goes to flex line
3. If flex full, reassign to backup-capable lines

Example Allocation:
v1 demand: 1,200 units (exceeds Line 1 capacity 1,000)
→ Line 1: 1,000 v1
→ Line 3: 200 v1 (overflow)

v2 demand: 700 units (within Line 2 capacity 800)
→ Line 2: 700 v2

v3 demand: 500 units
→ Line 3: 300 v3 (after v1 overflow)
→ Line 2: 200 v3 (backup capacity used)

Result: All demand met, all lines utilized 90%+
```

---

### 6.6.2 Inter-Line Dependencies

**Shared Resources:**
```
Problem: Lines compete for same resources

Example:
Line 1 (v1 production) needs Worker_Sarah (CNC expert)
Line 2 (v2 production) also needs Worker_Sarah
→ Conflict! Cannot be in two places

Resolution Strategies:

A) Priority-Based Assignment:
   Worker_Sarah → Line with highest-priority contract
   Line 2 gets Worker_Mike (less skilled, slower)

B) Time-Sharing:
   Worker_Sarah: 4 hours Line 1, 4 hours Line 2
   Reduces both lines' efficiency (setup time doubled)

C) Cross-Training:
   Train Worker_Mike to Sarah's skill level
   Cost: $3,000 + 2 weeks
   Benefit: Eliminates dependency

Player Decision: Choose strategy based on long-term vs short-term goals
```

**Material Flow Integration:**
```
Lines may share raw materials or sub-assemblies

Example:
v1 and v2 both use same engine block (different machining)

Shared Process:
Raw Material → Lathe (shared) → Diverge:
  → Line 1: CNC_v1 → Assembly_v1
  → Line 2: CNC_v2 → Assembly_v2

Planning Implication:
- Lathe must produce for BOTH lines
- If Lathe bottlenecks, BOTH lines stop
- MES must sequence blocks for v1 vs v2 optimally

Optimization:
Batch same-version blocks together (reduce changeover)
Example sequence: 20× v1 blocks, 15× v2 blocks, 20× v1, 15× v2...
```

---

## 6.7 Scenario Planning & Simulation

### 6.7.1 What-If Analysis

**In-Game Planning Tool:**
```
┌─ SCENARIO PLANNER ────────────────────────────────────┐
│                                                        │
│ Base Scenario: Current State                          │
│ • 3 CNC machines, 2 shifts                            │
│ • 4 active contracts, 2,100 units/month demand        │
│ • Current utilization: 94%                            │
│ • Current profit: $180k/month                         │
│                                                        │
│ What-If Scenarios:                                     │
│                                                        │
│ ┌─ Scenario A: Add CNC_04 ─────────────────────────┐ │
│ │ Investment: $38,000 (one-time)                   │ │
│ │ Operating: +$800/month                           │ │
│ │ Result:                                          │ │
│ │  • Utilization: 94% → 71% (healthy buffer)       │ │
│ │  • Profit: $180k → $205k/month (+14%)            │ │
│ │  • Payback: 2.4 months                           │ │
│ │  • Risk: LOW (demand supports capacity)          │ │
│ └──────────────────────────────────────────────────┘ │
│                                                        │
│ ┌─ Scenario B: Add 2nd Shift to CNC_02 ───────────┐ │
│ │ Investment: $0 (hire 1 worker)                   │ │
│ │ Operating: +$3,500/month (labor)                 │ │
│ │ Result:                                          │ │
│ │  • Utilization: 94% → 78%                        │ │
│ │  • Profit: $180k → $195k/month (+8%)             │ │
│ │  • Payback: Immediate (no capex)                 │ │
│ │  • Risk: MEDIUM (worker retention, fatigue)      │ │
│ └──────────────────────────────────────────────────┘ │
│                                                        │
│ ┌─ Scenario C: Reject AeroTech Contract ──────────┐ │
│ │ Impact: -400 units/month, -$160k revenue         │ │
│ │ Result:                                          │ │
│ │  • Utilization: 94% → 68% (large drop)           │ │
│ │  • Profit: $180k → $125k/month (-31%)            │ │
│ │  • Benefit: Capacity buffer for rush orders      │ │
│ │  • Risk: HIGH (revenue loss, customer relations) │ │
│ └──────────────────────────────────────────────────┘ │
│                                                        │
│ [Run Detailed Simulation] [Compare Side-by-Side]      │
└────────────────────────────────────────────────────────┘

Recommendation: Scenario A (Add CNC_04)
- Best ROI, lowest risk
- Enables growth (can accept more contracts next quarter)
- Avoid overtime stress on workers
```

---

## 6.8 Integration with MES & Real-Time Adjustments

**MES-Driven Dynamic Planning:**
```
Traditional Planning: Set schedule Monday, execute all week
MES Planning: Re-optimize every 4 hours based on actual performance

Example:
Monday 8 AM Plan:
- Line 1: 250 parts this week (v1)
- Line 2: 200 parts this week (v2)
- Line 3: 150 parts this week (v3)

Monday 2 PM Reality Check:
- Line 1: On track (62 parts done, target 63)
- Line 2: Behind (42 parts done, target 50) ⚠
- Line 3: Ahead (42 parts done, target 38) ✓

MES Auto-Adjustment:
- Reallocate Worker_Carlos from Line 3 → Line 2
- Result: Line 2 speeds up, Line 3 slows slightly
- New projections: All lines finish on time

Player Notification:
"✓ MES auto-optimized worker assignments
 Line 2 now projected to complete on schedule
 No action required (auto-pilot engaged)"

Player Override Available:
[Approve Auto-Adjustment] [Manual Control] [Review Details]
```

---

## 6.9 Advanced Planning Techniques (Late-Game)

### 6.9.1 Mixed Integer Linear Programming (MILP)

**Concept (Simplified for Game):**
```
Mathematical optimization to find best schedule

Variables:
- X_ij = parts of product i produced on line j
- Y_ik = worker k assigned to product i

Objective:
Maximize: Total Profit
= Σ (Revenue_i × X_ij) - Σ (Cost_k × Y_ik) - Σ (Overhead)

Constraints:
- Capacity: Σ X_ij ≤ LineCapacity_j
- Demand: Σ X_ij ≥ ContractDemand_i
- Workers: Σ Y_ik ≤ AvailableWorkers

Solution: Optimal allocation of products to lines + workers

In-Game Implementation:
- Player clicks "Optimize Schedule" (Tier 4 MES unlock)
- MES runs MILP solver (abstracted, instant in-game)
- Returns optimal schedule
- Player reviews, can tweak manually

Benefit: 5-15% profit improvement vs manual scheduling
```

---

### 6.9.2 Theory of Constraints (TOC) Five Focusing Steps

**Game Implementation:**
```
MES guides player through TOC process:

Step 1: IDENTIFY the constraint
→ MES highlights: "CNC_02 is bottleneck (97% utilization)"

Step 2: EXPLOIT the constraint
→ MES suggests: "Maximize CNC_02 uptime:
   - Schedule maintenance off-shift
   - Batch similar parts (reduce setup)
   - Assign best worker (Sarah) to CNC_02"

Step 3: SUBORDINATE everything else
→ MES adjusts: "Slow upstream Lathe to CNC_02 speed
   Reduce WIP buffer from 120 → 60 parts"

Step 4: ELEVATE the constraint
→ MES recommends: "Add 2nd CNC or upgrade CNC_02
   Investment: $38k, Payback: 2 months"

Step 5: REPEAT
→ After CNC added: "New bottleneck: Assembly_01 (now 95% utilization)
   Repeat process..."

Educational Value:
Player learns real industrial engineering principles while playing!
```

---

**End of Section 6 - Planning & Capacity Management**

Next: Section 7 (Research & Technology Tree) with detailed unlock progression...

---

# 7. RESEARCH & TECHNOLOGY TREE

## 7.1 Tech Tree Overview

The Technology Tree provides structured progression through unlockable machines, automation systems, MES capabilities, and advanced production features.

**Design Principles:**
- **Tiered Structure:** 6 tiers (0-5) from basic to endgame
- **Multiple Paths:** Quality vs Volume vs Automation specializations
- **Clear Prerequisites:** Each unlock has visible requirements
- **Meaningful Choices:** No "must-have" path, multiple strategies viable

---

## 7.2 Tech Tree Structure (Tiers 0-5)

**Tier 0: Starting Equipment (No Unlock Required)**
```
Available from start:
- CNC Mill (basic)
- CNC Lathe (basic)  
- Assembly Station
- Basic Conveyor
- 2 Workers (generalists)
- Manual parameter control
```

**Tier 1: Foundation (Levels 1-5)**
```
Unlocks Cost: 500-1,000 XP + $5k-$15k cash each

🔧 Worker Training System
   - Enables skill specializations (Machining, Assembly, QC)
   - Training duration: 1-2 weeks
   - Cost: $1,500-$3,000 per training
   - Benefit: +15-25% efficiency in specialty

🔧 MES GUI Presets
   - Pre-configured machine parameter sets
   - "High Speed" / "High Precision" / "Balanced"
   - One-click application
   - Benefit: +5-10% OEE vs manual

🔧 Quality Control Station
   - Basic dimensional inspection
   - Visual defect detection
   - Manual sampling (player sets rate)
   - Benefit: Catch 80% of defects before delivery

🔧 Basic Conveyor Network
   - Belt conveyors (straight, curved)
   - Simple routing (single path)
   - Benefit: Automated part transport

🔧 Material Storage Upgrade
   - Increased buffer capacity (50 → 200 parts)
   - Organized inventory system
   - Low-stock alerts
   - Benefit: Prevent production stoppages
```

**Tier 2: Automation Basics (Levels 6-11)**
```
Unlocks Cost: 2,000-4,000 XP + $25k-$50k cash each

🤖 MES Block Editor
   - Visual programming interface (drag-and-drop logic)
   - IF-THEN-ELSE conditional rules
   - Part version detection & routing
   - Benefit: +10-15% OEE, enables mixed-model production

🤖 Multi-Line Production
   - Run 2+ production lines simultaneously
   - Independent scheduling per line
   - Shared resource allocation
   - Benefit: 2× throughput capacity

🤖 Advanced QC Tools
   - Statistical Process Control (SPC) charts
   - Trend detection & alerts
   - Automated sampling rate adjustment
   - Benefit: Reduce scrap 30-40%

🤖 R&D Department
   - Hire R&D engineers
   - Develop in-house products
   - Co-development contracts
   - Benefit: Higher profit margins (25-50%)

🤖 Worker Cross-Training
   - Workers can cover multiple stations
   - Reduced downtime from absence
   - Flexible shift assignments
   - Benefit: +20% workforce utilization
```

**Tier 3: Advanced Optimization (Levels 12-17)**
```
Unlocks Cost: 5,000-10,000 XP + $75k-$150k cash each

⚙️ Advanced Scheduling Algorithms
   - Critical Ratio (deadline-aware)
   - Earliest Due Date (EDD)
   - Shortest Job First (SJF)
   - Benefit: -40% late deliveries

⚙️ MES Text Scripting (Lua-like)
   - Full programming capability
   - Access to all machine/part data
   - Custom functions & loops
   - Benefit: +15-20% OEE over block editor

⚙️ Predictive Maintenance (Basic)
   - Cycle count tracking
   - Scheduled PM reminders
   - Maintenance history logging
   - Benefit: -50% unplanned downtime

⚙️ Advanced Machines
   - CNC (high-precision): ±0.005mm tolerance
   - CNC (high-speed): 2× faster cycles
   - Multi-spindle lathe: 3 parts simultaneously
   - Benefit: Unlock premium contracts

⚙️ Line Balancing Tools
   - Bottleneck visualization (heatmaps)
   - Capacity vs demand charts
   - "What-if" scenario planning
   - Benefit: Optimize throughput +25%
```

**Tier 4: Advanced Automation (Levels 18-22)**
```
Unlocks Cost: 15,000-25,000 XP + $200k-$500k cash each

🚀 AGVs (Automated Guided Vehicles)
   - Fleet of 2-10 AGVs
   - Dynamic routing (MES-controlled)
   - Battery management (auto-charge)
   - Benefit: +15% worker productivity (no material transport)

🚀 Predictive Maintenance (Advanced)
   - Vibration analysis sensors
   - Temperature monitoring
   - AI failure prediction (3-5 days warning)
   - Benefit: -80% unplanned downtime

🚀 Digital Twin Simulation
   - Virtual factory replica
   - Test production changes risk-free
   - "What-if" optimization
   - Benefit: Validate decisions before implementation

🚀 Six Sigma Certification
   - Advanced quality methodologies
   - Root cause analysis tools
   - Defect prevention workflows
   - Benefit: <0.5% scrap rate achievable

🚀 Global Supply Chain
   - Multiple material suppliers
   - Hedge against price/delay risk
   - Auto-switching on disruption
   - Benefit: -60% supply disruption impact
```

**Tier 5: Mastery & Endgame (Levels 23-25)**
```
Unlocks Cost: 40,000-80,000 XP + $1M-$5M cash each

💎 AI-Assisted MES Optimization
   - AI analyzes production data
   - Suggests parameter improvements
   - Auto-tune (player approval required)
   - Benefit: +5-10% OEE (finds optimizations humans miss)

💎 Multi-Factory Management
   - Open 2nd factory (different region)
   - Global production coordination
   - Regional cost/skill differences
   - Benefit: 2× production, geographic diversification

💎 Quantum Factory (Prestige Item)
   - Experimental ultra-fast machines
   - 5× speed, 0% scrap
   - Extremely expensive ($5M+)
   - Benefit: Endgame flex, not required

💎 Full Automation Suite
   - Lights-out manufacturing (48hr autonomous)
   - Self-healing systems (auto-recovery from errors)
   - AI worker assignment
   - Benefit: Minimal player intervention required

💎 Industry Leadership
   - Exclusive contracts (government, aerospace)
   - Influence market prices
   - Mentor competitors (co-op mode)
   - Benefit: Prestige, unique content
```

---

## 7.3 Tech Tree Paths & Strategies

**Path A: Quality Focus**
```
Priority: SPC → Six Sigma → Predictive Maintenance → Advanced Machines

Best For:
- Low-volume, high-value products
- Premium contracts (aerospace, medical)
- Players who enjoy perfectionism

Example Build:
Level 8: Unlock Advanced QC (SPC charts)
Level 12: Six Sigma certification
Level 18: Predictive maintenance (prevent quality issues)
Level 22: Ultra-precision CNC

Result: <0.5% scrap, highest margins, slower growth
```

**Path B: Volume Focus**
```
Priority: Multi-Line → AGVs → Advanced Scheduling → High-Speed Machines

Best For:
- High-volume, cost-competitive products
- OEM manufacturing contracts
- Players who like optimization puzzles

Example Build:
Level 6: Multi-line production
Level 12: Advanced scheduling (maximize throughput)
Level 18: AGVs (reduce transport bottlenecks)
Level 22: High-speed CNC (2× faster)

Result: 3-4% scrap (acceptable), high throughput, best revenue
```

**Path C: Automation Focus**
```
Priority: MES Block Editor → MES Scripting → AGVs → AI Optimization

Best For:
- Multi-product factories
- Players who enjoy coding/logic
- Hands-off gameplay style

Example Build:
Level 6: MES Block Editor
Level 12: MES Text Scripting
Level 18: AGVs + Digital Twin
Level 23: AI-assisted optimization

Result: Highly automated, efficient, scalable
```

**Path D: Business Focus**
```
Priority: R&D → Worker Cross-Training → Global Supply Chain → Multi-Factory

Best For:
- Strategic/business-minded players
- Long-term growth focus
- Diversification strategy

Example Build:
Level 8: R&D department (develop proprietary products)
Level 12: Worker cross-training (flexibility)
Level 18: Global supply chain (risk management)
Level 23: Multi-factory (empire building)

Result: Highest long-term profits, strategic depth
```

---

## 7.4 Unlock Costs & XP Economy

**XP Requirements (Cumulative):**
```
Level 1 → 2: 1,000 XP
Level 5 → 6: 6,000 XP (total from start)
Level 10 → 11: 20,000 XP
Level 15 → 16: 60,000 XP
Level 20 → 21: 130,000 XP
Level 25 (Max): 300,000 XP total
```

**Cash Requirements:**
```
Tier 1 unlocks: $5k-$15k (affordable early)
Tier 2 unlocks: $25k-$50k (mid-game investment)
Tier 3 unlocks: $75k-$150k (requires stable cash flow)
Tier 4 unlocks: $200k-$500k (major capex decisions)
Tier 5 unlocks: $1M-$5M (endgame only)
```

**Strategic Trade-offs:**
```
Question: "Spend on tech or expand production?"

Early Game (L1-8):
- Tech is expensive relative to earnings
- Better to buy 2nd machine than tech
- Focus: Build cash flow first

Mid Game (L9-16):
- Balanced tech + expansion
- Tech unlocks enable higher-value contracts
- Focus: Strategic tech choices

Late Game (L17+):
- Cash abundant, XP is bottleneck
- Can afford most techs
- Focus: Optimize choices for endgame strategy
```

---

## 7.5 Tech Tree UI/UX

**Visual Design:**
```
┌─────────────────────────────────────────────┐
│ TECHNOLOGY TREE                             │
├─────────────────────────────────────────────┤
│                                             │
│  TIER 0 (Start) ──→ TIER 1 ──→ TIER 2      │
│  [CNC][Lathe]   [Training] [MES Blocks]     │
│      ↓              ↓          ↓            │
│  Always         [MES GUI]  [Multi-Line]     │
│  Available      [QC Tool]  [R&D Dept]       │
│                     ↓          ↓            │
│              ──→ TIER 3 ──→ TIER 4 ──→      │
│              [Scheduling] [AGVs]            │
│              [MES Script] [Predictive]      │
│                  ↓             ↓            │
│              ──→ TIER 5 (Mastery)           │
│              [AI Optimize] [Multi-Factory]  │
│                                             │
│  Legend:                                    │
│  🟢 Unlocked  🔒 Locked  ⭐ Available Now   │
│                                             │
│  [View: All | Quality | Volume | Auto]      │
└─────────────────────────────────────────────┘
```

**Node Details (Click to Expand):**
```
Clicked: "MES Block Editor"

┌──────────────────────────────────────┐
│ MES BLOCK EDITOR                     │
├──────────────────────────────────────┤
│ Tier: 2                              │
│ Status: 🔒 Locked                    │
│                                      │
│ REQUIREMENTS:                        │
│ • Level 6 or higher ✓                │
│ • MES GUI Presets unlocked ✓         │
│ • 3,000 XP ✗ (currently 2,450)       │
│ • $40,000 cash ✓                     │
│                                      │
│ BENEFITS:                            │
│ • Create custom automation rules     │
│ • +10-15% OEE                        │
│ • Enable mixed-model production      │
│ • Unlock advanced contracts          │
│                                      │
│ DESCRIPTION:                         │
│ Visual programming interface for     │
│ creating IF-THEN logic to automate   │
│ machine parameters and part routing. │
│                                      │
│ [Unlock Now] (if requirements met)   │
│ [Learn More] [Close]                 │
└──────────────────────────────────────┘
```

---

# 8. UI/UX DESIGN (COMPREHENSIVE)

## 8.1 Design Philosophy

**Core Principles:**

1. **Information at a Glance:** Critical data always visible, detailed data 1 click away
2. **Progressive Disclosure:** Tutorial hides complexity, advanced players access everything
3. **Contextual Help:** Tooltips, tutorials, integrated help system
4. **Responsive Design:** Works on 1920×1080 (primary), scales to 1280×720 (minimum)
5. **Accessibility First:** Colorblind safe, text scaling, keyboard navigation

**Visual Style:**

- **Art Style:** Flat design with subtle depth (long shadows, clean lines)
- **Color Palette:** Industrial grays/blues (calm) + accent colors for states (green=good, yellow=warning, red=error)
- **Typography:** Roboto (sans-serif, clean, readable at small sizes)
- **Iconography:** Consistent 32×32px icons, high-contrast, simple shapes

---

## 8.2 Main Game Screen Layout

```
┌─────────────────────────────────────────────────────────────────────┐
│ ╔═══════════════════════════════════════════════════════════════╗  │
│ ║ TOP BAR (60px height)                                          ║  │
│ ║ Logo | Cash: $142,500 | XP: Lvl 12 (68%) | Contracts: 3      ║  │
│ ╚═══════════════════════════════════════════════════════════════╝  │
├──────────┬───────────────────────────────────────────┬──────────────┤
│          │                                           │              │
│  LEFT    │         MAIN CANVAS (Factory View)        │    RIGHT     │
│ SIDEBAR  │                                           │   SIDEBAR    │
│          │  [Top-down 2D grid view of factory]       │              │
│ (280px)  │                                           │   (320px)    │
│          │  - Machines (animated sprites)            │              │
│ Machine  │  - Workers (moving icons)                 │  Dashboard   │
│ List     │  - Conveyors (animated flow)              │  Panels      │
│          │  - Parts (moving between stations)        │              │
│ Quick    │  - Overlays (heatmaps, flow)              │  Contract    │
│ Actions  │                                           │  Status      │
│          │  Zoom: [25% | 50% | 100% | 150%]          │              │
│ Filters  │  View: [Normal | Bottleneck | Quality]    │  MES         │
│          │                                           │  Controls    │
│          │                                           │              │
│          │                                           │  Alerts      │
│          │                                           │              │
│          │                                           │  KPIs        │
├──────────┴───────────────────────────────────────────┴──────────────┤
│ ╔═══════════════════════════════════════════════════════════════╗  │
│ ║ BOTTOM BAR (80px height) - Timeline / Event Log              ║  │
│ ║ [Recent events scroll] | Game Speed: [1x][2x][5x] | Pause    ║  │
│ ╚═══════════════════════════════════════════════════════════════╝  │
└─────────────────────────────────────────────────────────────────────┘
```

**Responsive Breakpoints:**

- **1920×1080 (Default):** Full layout as shown
- **1600×900:** Sidebars 240px/280px, slightly compressed
- **1280×720 (Minimum):** Sidebars collapsible (toggle), canvas remains usable

---

## 8.3 Top Bar (Persistent HUD)

```
┌──────────────────────────────────────────────────────────────────┐
│ [LOGO] ENGINE ASSEMBLY TYCOON                                    │
│                                                                  │
│ 💰 $142,500 (+$8,200/day)  ⭐ Level 12 (68% to next)  📊 OEE: 78%│
│                                                                  │
│ 📋 Contracts: 3 active  ⚠️ Alerts: 2  🔔 Notifications: 5       │
│                                                                  │
│ [Settings ⚙] [Help 💡] [Menu ☰]                                 │
└──────────────────────────────────────────────────────────────────┘
```

**Interactions:**

- **Cash:** Click → opens Economy panel (detailed P&L, cost breakdown)
- **XP Bar:** Click → opens Level Progress panel (current perks, next unlock)
- **OEE:** Click → opens Performance Dashboard (detailed OEE breakdown)
- **Contracts:** Click → opens Contract Manager
- **Alerts:** Click → opens Alert List (prioritized by severity)
- **Notifications:** Click → opens Event Log

**Tooltips (Hover):**

```
Hover on Cash:
┌────────────────────────────┐
│ Current Cash: $142,500     │
│ Daily Revenue: +$12,800    │
│ Daily Costs: -$4,600       │
│ Net: +$8,200/day          │
│                            │
│ Click for details          │
└────────────────────────────┘
```

---

## 8.4 Left Sidebar - Machine List & Quick Actions

```
┌───────────────────────────┐
│ MACHINE LIST              │
├───────────────────────────┤
│                           │
│ 🟢 CNC_01 (Running)       │
│    Part: ENG-v2-S00542    │
│    Progress: ████▒ 75%    │
│                           │
│ 🟢 CNC_02 (Running)       │
│    Part: ENG-v1-S00789    │
│    Progress: ██▒▒▒ 38%    │
│                           │
│ 🟡 Lathe_01 (Setup)       │
│    Worker: Sarah          │
│    ETA: 2 min             │
│                           │
│ 🔴 Assembly_03 (Error)    │
│    Issue: Torque fault    │
│    [Fix] [Details]        │
│                           │
│ ⚪ QC_01 (Idle)            │
│    Ready for work         │
│                           │
├───────────────────────────┤
│ QUICK ACTIONS             │
├───────────────────────────┤
│ [+ Add Machine]           │
│ [👷 Hire Worker]          │
│ [📦 Order Materials]      │
│ [🔧 Schedule Maint.]      │
├───────────────────────────┤
│ VIEW FILTERS              │
├───────────────────────────┤
│ ☑ Show All Machines       │
│ ☐ Running Only            │
│ ☐ Errors Only             │
│ ☐ Hide Idle               │
│                           │
│ OVERLAYS:                 │
│ ○ Normal View             │
│ ○ Bottleneck Heatmap      │
│ ○ Quality Issues          │
│ ○ Worker Activity         │
└───────────────────────────┘
```

**Machine List Entry (Expanded on Click):**

```
┌────────────────────────────────────┐
│ 🟢 CNC_02 - RUNNING                │
├────────────────────────────────────┤
│ Current Job:                       │
│  Part: Engine Block v2             │
│  Serial: ENG-v2-S00542             │
│  Progress: 75% (9 min remaining)   │
│                                    │
│ Machine Status:                    │
│  Spindle: 2487 RPM (Target: 2500)  │
│  Feed Rate: 248 mm/min             │
│  Tool: End Mill 12mm (66% wear)    │
│  Power: 7.2 kW                     │
│                                    │
│ Worker: Sarah (Skill 95)           │
│                                    │
│ [Pause] [Adjust Parameters]        │
│ [View Details] [Maintenance]       │
└────────────────────────────────────┘
```

---

## 8.5 Right Sidebar - Dashboard Panels (Tabbed Interface)

```
┌─────────────────────────────────────┐
│ [Contracts][MES][Alerts][KPIs][...]│ ← Tabs
├─────────────────────────────────────┤
│                                     │
│  ╔═ ACTIVE CONTRACTS ═════════════╗│
│  ║                                ║│
│  ║ 📋 Contract A (OEM Motors)     ║│
│  ║    200 engines v1              ║│
│  ║    Progress: 145/200 (73%)     ║│
│  ║    Deadline: 3 days, 14 hours  ║│
│  ║    Status: ON TRACK ✓          ║│
│  ║    [Details]                   ║│
│  ║                                ║│
│  ║ 📋 Contract B (Premium Auto)   ║│
│  ║    150 engines v2              ║│
│  ║    Progress: 87/150 (58%)      ║│
│  ║    Deadline: 6 days, 2 hours   ║│
│  ║    Status: SLIGHT DELAY ⚠️     ║│
│  ║    [Details] [Prioritize]      ║│
│  ║                                ║│
│  ║ 📋 Contract C (Startup)        ║│
│  ║    80 engines v3               ║│
│  ║    Progress: 12/80 (15%)       ║│
│  ║    Deadline: 12 days           ║│
│  ║    Status: ON TRACK ✓          ║│
│  ║    [Details]                   ║│
│  ║                                ║│
│  ║ [View All Contracts]           ║│
│  ╚════════════════════════════════╝│
│                                     │
└─────────────────────────────────────┘
```

**Tab: MES Controls**

```
┌─────────────────────────────────────┐
│ [Contracts][MES][Alerts][KPIs][...]│
├─────────────────────────────────────┤
│                                     │
│  ╔═ MES CONTROL ═══════════════════╗│
│  ║                                 ║│
│  ║ Active Rules: 3                 ║│
│  ║                                 ║│
│  ║ ✓ Multi-Product Auto-Config     ║│
│  ║   (v1, v2, v3 handling)         ║│
│  ║   Efficiency: +12%              ║│
│  ║   [Edit]                        ║│
│  ║                                 ║│
│  ║ ✓ Tool Wear Compensation        ║│
│  ║   Feed rate auto-adjust         ║│
│  ║   Tool life: +18%               ║│
│  ║   [Edit]                        ║│
│  ║                                 ║│
│  ║ ✓ Adaptive QC Sampling          ║│
│  ║   Sample rate: 5-30% dynamic    ║│
│  ║   QC cost: -22%                 ║│
│  ║   [Edit]                        ║│
│  ║                                 ║│
│  ║ [+ Create New Rule]             ║│
│  ║ [Open Block Editor]             ║│
│  ║ [View Templates]                ║│
│  ║                                 ║│
│  ║ QUICK STATS:                    ║│
│  ║ MES Efficiency Bonus: +17.4%    ║│
│  ║ Scrap Reduction: -8.2%          ║│
│  ║ [View Full Analytics]           ║│
│  ╚═════════════════════════════════╝│
│                                     │
└─────────────────────────────────────┘
```

**Tab: Alerts**

```
┌─────────────────────────────────────┐
│ [Contracts][MES][Alerts][KPIs][...]│
├─────────────────────────────────────┤
│                                     │
│  ╔═ ALERTS (Prioritized) ══════════╗│
│  ║                                 ║│
│  ║ 🔴 CRITICAL (1)                 ║│
│  ║ Assembly_03: Torque fault       ║│
│  ║ Action required immediately     ║│
│  ║ [Fix Now] [Assign Worker]       ║│
│  ║                                 ║│
│  ║ 🟡 WARNING (2)                  ║│
│  ║ CNC_02: Tool wear 75%           ║│
│  ║ Replace within 2 hours          ║│
│  ║ [Schedule] [Override]           ║│
│  ║                                 ║│
│  ║ Buffer_A: 85% full              ║│
│  ║ Potential bottleneck            ║│
│  ║ [View] [Adjust Flow]            ║│
│  ║                                 ║│
│  ║ 🔵 INFO (3)                     ║│
│  ║ Material delivery arriving 2pm  ║│
│  ║ Worker_Sarah earned cert        ║│
│  ║ New contract available          ║│
│  ║ [Dismiss All Info]              ║│
│  ╚═════════════════════════════════╝│
│                                     │
└─────────────────────────────────────┘
```

**Tab: KPIs (Key Performance Indicators)**

```
┌─────────────────────────────────────┐
│ [Contracts][MES][Alerts][KPIs][...]│
├─────────────────────────────────────┤
│                                     │
│  ╔═ PERFORMANCE ════════════════════╗│
│  ║                                 ║│
│  ║ OEE: 78.2% [████████▒] 85%      ║│
│  ║   Availability: 89%             ║│
│  ║   Performance: 91%              ║│
│  ║   Quality: 97%                  ║│
│  ║                                 ║│
│  ║ Throughput: 7.2 units/hr        ║│
│  ║ Trend: ▲ +0.4 vs last week      ║│
│  ║                                 ║│
│  ║ Scrap Rate: 2.8%                ║│
│  ║ Trend: ▼ -1.2% (improving!)     ║│
│  ║                                 ║│
│  ║ Cost per Unit: $168.50          ║│
│  ║ Target: $165.00 (△ $3.50)       ║│
│  ║                                 ║│
│  ║ Worker Efficiency: 87%          ║│
│  ║ Morale: 82% (Good ✓)            ║│
│  ║                                 ║│
│  ║ [Detailed Analytics]            ║│
│  ║ [Export Report]                 ║│
│  ╚═════════════════════════════════╝│
│                                     │
└─────────────────────────────────────┘
```

---

## 8.6 Main Canvas - Factory Floor View

**Visual Elements:**

**Grid System:**
- 64×64px cells (1m² in-game)
- Default view: 30×30 grid (expandable to 100×100 late-game)
- Grid lines: Subtle gray (toggleable)
- Snap-to-grid: ON by default (can disable for freeform placement)

**Machine Sprites:**
- **CNC/Lathe:** 3×3 cells (192×192px sprite)
- **Assembly:** 2×2 cells
- **Nutrunner:** 1×1 cell
- **Conveyor:** 1×1 cell per segment
- **Buffer:** 2×1 cells

**Animation States:**
- **Idle:** Static sprite, slight pulsing glow
- **Running:** Animated (rotating tools, moving parts)
- **Error:** Red pulsing border, alert icon
- **Maintenance:** Orange wrench icon overlay

**Worker Representation:**
- Small human icon (32×32px)
- Moves along paths (A* pathfinding)
- Carries part icon when transporting
- Speech bubble shows current task (on hover)

**Part Flow Visualization:**
- Small squares (16×16px) moving along conveyors
- Color-coded by product variant:
  - v1: Blue
  - v2: Green
  - v3: Orange
- Trail effect shows recent movement

**Overlay Modes:**

**1. Normal View (Default)**
```
Standard factory view, all colors normal
Machines: Gray/metallic
Conveyors: Dark gray
Workers: Blue
```

**2. Bottleneck Heatmap**
```
Color intensity = utilization %
Green: <60% (underutilized)
Yellow: 60-80% (balanced)
Orange: 80-95% (high utilization)
Red: >95% (bottleneck!)

Hovering shows:
"CNC_02: 94% utilization (bottleneck risk)"
```

**3. Quality Heatmap**
```
Color = recent scrap rate
Green: <1% (excellent)
Yellow: 1-3% (acceptable)
Red: >3% (problem area)

Clicking opens QC analysis panel for that machine
```

**4. Worker Activity**
```
Highlights worker paths, idle time
Green trail: Productive movement
Gray: Idle/waiting
Red: Excessive travel (layout inefficiency)
```

---

## 8.7 Bottom Bar - Timeline & Event Log

```
┌──────────────────────────────────────────────────────────────────┐
│ EVENT LOG (scrolling left)                                       │
│ ← 10:42 Contract A: +25 units | 10:38 CNC_02 cycle complete |   │
│   10:35 Worker_Sarah: Level up! | 10:30 Material delivered      │
├──────────────────────────────────────────────────────────────────┤
│ GAME SPEED:  [Pause ⏸] [1x ▶] [2x ▶▶] [5x ▶▶▶]   Time: Day 12   │
└──────────────────────────────────────────────────────────────────┘
```

**Event Log Colors:**
- **Green:** Positive events (contract milestone, level up)
- **Yellow:** Neutral (material delivery, shift change)
- **Red:** Negative (machine error, QC failure)
- **Blue:** Informational (worker break, maintenance scheduled)

**Click Event:** Opens detail panel
```
Clicked: "CNC_02 cycle complete"

┌──────────────────────────────────┐
│ Cycle Complete: CNC_02           │
├──────────────────────────────────┤
│ Part: ENG-v2-S00542              │
│ Cycle Time: 11.8 min (target 12) │
│ Quality: PASS ✓                  │
│ Next: Send to Assembly_03        │
│                                  │
│ [View Part Genealogy]            │
│ [View Machine Stats]             │
└──────────────────────────────────┘
```

---

## 8.8 Modal Windows & Panels

### 8.8.1 Contract Detail Panel

```
┌───────────────────────────────────────────────────────────────┐
│ CONTRACT DETAILS: OEM Motors Partnership                      │
├───────────────────────────────────────────────────────────────┤
│                                                               │
│ Customer: Acme Automotive                                     │
│ Type: OEM Manufacturing                                       │
│ Duration: 4 weeks (started 8 days ago)                        │
│                                                               │
│ ━━━ REQUIREMENTS ━━━                                          │
│ Product: Engine v1 (baseline model)                           │
│ Quantity: 200 units                                           │
│ Quality: <2% defect rate                                      │
│ Delivery: Weekly milestones (50 units/week)                   │
│                                                               │
│ ━━━ PROGRESS ━━━                                              │
│ Week 1: 52/50 ✓ (delivered on time, +$500 bonus)             │
│ Week 2: 48/50 ⚠️ (2 units short, -$200 penalty)              │
│ Week 3 (current): 38/50 (ON TRACK, 3 days remaining)          │
│ Total: 138/200 (69%)                                          │
│                                                               │
│ ━━━ QUALITY METRICS ━━━                                       │
│ Defects: 3/138 (2.2%) ⚠️ Slightly over target                │
│ Rework: 1 unit (caught in QC, fixed)                          │
│                                                               │
│ ━━━ FINANCIAL ━━━                                             │
│ Base Payment: $400/unit × 200 = $80,000                       │
│ Bonuses Earned: +$500 (Week 1 on-time)                        │
│ Penalties: -$200 (Week 2 shortfall)                           │
│ Current Total: $80,300 (projected)                            │
│                                                               │
│ If Perfect Completion:                                        │
│  - On-time bonus: +$5,000                                     │
│  - Quality bonus (<1.5%): +$3,000                             │
│  - Potential Total: $88,300                                   │
│                                                               │
│ ━━━ ACTIONS ━━━                                               │
│ [Prioritize This Contract] (boosts production schedule)       │
│ [Contact Customer] (negotiate extension/changes)              │
│ [View Production Plan]                                        │
│ [Close]                                                       │
└───────────────────────────────────────────────────────────────┘
```

### 8.8.2 MES Block Editor (Full Screen Modal)

*(Already detailed in Section 3, reference that design)*

### 8.8.3 Machine Detail Panel

```
┌─────────────────────────────────────────────────────────────────┐
│ MACHINE DETAILS: CNC_02                                         │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│ [Status] [Performance] [Maintenance] [History] ← Tabs           │
│                                                                 │
│ ━━━ STATUS ━━━                                                  │
│                                                                 │
│ Current State: RUNNING ●                                        │
│ Uptime: 6 hours, 32 minutes (this shift)                       │
│                                                                 │
│ Current Job:                                                    │
│  Part: Engine Block v2 (ENG-v2-S00542)                         │
│  Progress: 75% complete                                         │
│  Estimated Completion: 9 minutes                                │
│  NC Program: PROG_ENG_BLK_V2_FINISH.nc                         │
│                                                                 │
│ Operator: Worker_Sarah (Skill 95, Machining Specialist)        │
│                                                                 │
│ Real-Time Telemetry:                                            │
│  Spindle Speed: 2487 RPM (Target: 2500 RPM) ━ 99%              │
│  Feed Rate: 248 mm/min (Target: 250) ━ 99%                     │
│  Power Draw: 7.2 kW                                             │
│  Coolant Flow: 12.3 L/min ✓                                    │
│  Vibration: 2.4 mm/s (Normal) ✓                                │
│                                                                 │
│ Current Tool:                                                   │
│  Type: End Mill 12mm (S/N: EM-12-0042)                         │
│  Wear: 66% [████████░░] (replace at 80%)                       │
│  Cycles Remaining: ~170                                         │
│                                                                 │
│ ━━━ QUICK ACTIONS ━━━                                           │
│ [Pause Production] [Adjust Parameters] [Schedule Maintenance]   │
│ [Replace Tool Now] [View Genealogy] [Export Data]              │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

---

## 8.9 Interaction Patterns & Controls

**Mouse Controls:**

| Action | Input | Result |
|--------|-------|--------|
| Select Machine | Left-click | Opens machine detail panel |
| Multi-Select | Ctrl+Click / Drag box | Select multiple machines |
| Pan Camera | Middle-mouse drag OR Arrow keys | Move view |
| Zoom | Mouse wheel | Zoom in/out (25%-200%) |
| Context Menu | Right-click | Opens contextual actions |
| Place Machine | Drag from sidebar | Ghost preview, click to place |

**Keyboard Shortcuts:**

| Key | Action |
|-----|--------|
| Space | Pause/Unpause |
| 1, 2, 5 | Set game speed (1x, 2x, 5x) |
| M | Open MES panel |
| C | Open Contracts panel |
| P | Open Planning panel |
| ESC | Close modal / Cancel action |
| Delete | Delete selected machine |
| Ctrl+Z | Undo last placement |
| Tab | Cycle through alerts |
| F1 | Help/Tutorial |

**Touch/Gestures (Future Mobile Support):**

- Pinch: Zoom
- Two-finger drag: Pan
- Tap: Select
- Long press: Context menu
- Swipe: Navigate between panels

---

## 8.10 Color-Coding System (Accessibility)

**Machine States:**

| State | Color | Icon | Pattern (Colorblind) |
|-------|-------|------|----------------------|
| Running | Green | ● | Solid fill |
| Idle | Gray | ○ | Empty |
| Setup | Yellow | ◐ | Horizontal lines |
| Maintenance | Orange | 🔧 | Diagonal lines |
| Error | Red | ⚠ | Crosshatch |
| Paused | Blue | ⏸ | Vertical lines |

**Quality Indicators:**

| Quality | Color | Symbol |
|---------|-------|--------|
| Excellent (<1%) | Dark Green | ★★★ |
| Good (1-2%) | Green | ★★ |
| Acceptable (2-3%) | Yellow | ★ |
| Poor (3-5%) | Orange | ⚠ |
| Critical (>5%) | Red | ✕ |

**Contract Status:**

| Status | Color | Badge |
|--------|-------|-------|
| Ahead of Schedule | Blue | +2 days |
| On Track | Green | ✓ |
| Minor Delay | Yellow | ⚠ 1 day |
| Critical Delay | Red | ⚠ 5 days |
| Complete | Green | ✓ Done |
| Failed | Red | ✕ |

---

## 8.11 Tooltips & Contextual Help

**Tooltip System:**

```
Hover Duration: 0.5 seconds
Fade In: 0.2 seconds
Max Width: 320px
Font Size: 12px
Background: Semi-transparent dark gray (#333333CC)
Border: 1px solid #555555
```

**Example Tooltip (Machine):**

```
Hover on CNC_02:

┌──────────────────────────────┐
│ CNC_02 - RUNNING             │
├──────────────────────────────┤
│ Current Part: ENG-v2-S00542  │
│ Progress: 75% (9 min left)   │
│ Operator: Sarah (Skill 95)   │
│ Tool Wear: 66%               │
│                              │
│ Click for details            │
│ Right-click for actions      │
└──────────────────────────────┘
```

**Tutorial Overlays:**

```
First time player sees MES panel:

┌─────────────────────────────────────┐
│ 💡 TIP: MES System                  │
├─────────────────────────────────────┤
│ The MES (Manufacturing Execution    │
│ System) automates your factory.     │
│                                     │
│ Start with simple presets, then     │
│ unlock the Block Editor to create   │
│ custom automation rules.            │
│                                     │
│ [Got it!] [Learn More] [Don't show] │
└─────────────────────────────────────┘
```

---

## 8.12 Accessibility Features

**Colorblind Modes:**

- **Protanopia (Red-blind):** Replace red with blue, adjust green
- **Deuteranopia (Green-blind):** Replace green with blue, adjust red
- **Tritanopia (Blue-blind):** Replace blue with red, adjust green
- **Full Colorblind:** Use patterns + icons ONLY (no color dependency)

**Text Scaling:**

- **Small:** 100% (default, 12px body text)
- **Medium:** 125% (15px body text)
- **Large:** 150% (18px body text)
- **Extra Large:** 200% (24px body text)

**High Contrast Mode:**

- Black background (#000000)
- White text (#FFFFFF)
- High contrast colors for states (no pastels)
- Thicker borders (2px minimum)

**Screen Reader Support:**

- All UI elements have ARIA labels
- Keyboard navigation fully supported
- Focus indicators visible (2px yellow outline)
- Screen reader announces state changes ("Machine CNC_02 now running")

**Reduce Motion:**

- Toggle OFF: Animations, particles, screen shake
- Toggle ON: Instant transitions, static sprites

---

## 8.13 UI Feedback & Juice

**Button Feedback:**

- Hover: Lighten 10%, subtle scale 1.05x
- Click: Darken 5%, scale 0.95x (150ms)
- Sound: Soft click (SFX)

**Success Animations:**

- Contract Complete: Confetti particle burst, success chime
- Level Up: Screen flash (white, 200ms), triumphant sound
- Perfect Quality (0 defects): Golden sparkle effect on QC station

**Error Feedback:**

- Machine Error: Red pulse (500ms), error buzz sound
- Invalid Action: Screen shake (2px, 100ms), rejection sound
- Low Cash: Cash counter flashes red when trying to buy

**Progress Indicators:**

- Production Progress: Smooth animated bar (0-100%)
- Loading: Spinning gear icon + progress %
- Processing: Animated dots "Processing..."

---

**End of Section 8 - UI/UX Design**

---

# 9. CHALLENGES & ADVANCED GAMEPLAY

## 9.1 Challenge System Overview

**Purpose:** Provide structured scenarios that teach advanced techniques while rewarding strategic mastery.

**Design Philosophy:**
- **Optional but Rewarding:** Challenges are never mandatory but offer significant bonuses
- **Teaching Tools:** Each challenge introduces a new optimization technique
- **Scalable Difficulty:** Bronze/Silver/Gold tiers for same challenge
- **Replayability:** Random elements ensure different solutions each time

**Reward Structure:**
- **Challenge Points (CP):** Special currency for unlocking rare upgrades
- **XP Bonus:** 2-5× normal XP for challenge completion
- **Unlockables:** Exclusive machines, MES templates, cosmetic items
- **Achievements:** Steam achievements tied to challenge mastery

---

## 9.2 Challenge Categories

### 9.2.1 Production Efficiency Challenges

**Challenge: "Speed Demon"**
```
Goal: Produce 100 engines in minimum time
Constraints: Fixed resources (3 machines, 5 workers, standard materials)
Difficulty Tiers:
  Bronze: <24 hours → +500 CP
  Silver: <20 hours → +1,200 CP
  Gold: <16 hours → +3,000 CP

Key Skills Tested:
- Worker scheduling optimization
- Machine utilization (minimize idle time)
- Basic MES automation (reduce cycle times)

Strategy Hints:
- Use MES to eliminate manual parameter entry (saves ~30 sec/part)
- Cross-train workers to cover multiple stations
- Sequence production to minimize changeovers
```

**Challenge: "Zero Waste"**
```
Goal: Produce 50 engines with <0.5% scrap rate
Constraints: Mixed product types (v1, v2, v3), aging machines (60% tool wear)
Difficulty Tiers:
  Bronze: <1% scrap → +600 CP
  Silver: <0.5% scrap → +1,500 CP  
  Gold: 0% scrap → +5,000 CP

Key Skills Tested:
- Predictive tool replacement
- MES quality control automation
- SPC (Statistical Process Control) usage

Strategy Hints:
- Replace tools proactively at 70% wear (don't wait for 80%)
- Use MES adaptive QC (increase sampling when scrap trend detected)
- Slow down rather than risk defects (time penalty < scrap penalty)
```

---

### 9.2.2 Multi-Product Complexity Challenges

**Challenge: "Mixed Model Master"**
```
Goal: Produce 3 engine variants simultaneously with minimal changeover
Setup: 1 production line, must produce v1, v2, v3 in ratio 5:3:2
Target: Complete 100 engines (50 v1, 30 v2, 20 v3)
Constraints: Each changeover >2 minutes incurs time penalty

Difficulty Tiers:
  Bronze: <15 changeovers → +800 CP
  Silver: <8 changeovers → +2,000 CP
  Gold: 0 changeovers (pure mixed-model) → +6,000 CP

Key Skills Tested:
- MES auto-configuration (RFID-based part recognition)
- Smart sequencing (Heijunka production smoothing)
- Part proliferation management (kanban bins)

Strategy Hints:
- Gold tier requires MES Block Editor (Tier 2 unlock minimum)
- Use RFID part tagging to trigger automatic recipe changes
- Sequence: v1, v2, v3, v1, v2, v1, v2, v3... (maintains 5:3:2 ratio)
- Smart kanban prevents wrong-part assembly errors
```

**Challenge: "Version Chaos"**
```
Goal: Handle 5 part versions concurrently with ECO (Engineering Change Order) mid-production
Scenario:
  - Start producing v1, v2, v3 (100 parts each)
  - At 50% completion, ECO changes v2 specs (torque 85→95 Nm)
  - Must complete both old v2 and new v2 without mixing them up

Difficulty Tiers:
  Bronze: Complete with <5% mix-up errors → +1,000 CP
  Silver: Complete with 0 mix-up errors → +2,500 CP
  Gold: Complete + deliver early → +7,000 CP

Key Skills Tested:
- Part genealogy tracking (serial numbers prevent mix-ups)
- MES version-aware routing
- ECO implementation under pressure

Strategy Hints:
- Immediately halt v2 production when ECO arrives
- Update MES rules for new v2 before resuming
- Use serialization to track which v2 parts are old vs new specs
- QC must check different tolerances for old vs new v2
```

---

### 9.2.3 Contract Fulfillment Challenges

**Challenge: "Deadline Pressure"**
```
Goal: Complete 3 simultaneous contracts with tight, overlapping deadlines
Contracts:
  A: 200 v1 engines, 5 days
  B: 150 v2 engines, 6 days  
  C: 100 v3 engines, 4 days (earliest deadline!)

Difficulty Tiers:
  Bronze: All delivered (late OK, <$10k penalties) → +900 CP
  Silver: All on-time → +2,200 CP
  Gold: All early + quality bonus → +8,000 CP

Key Skills Tested:
- Production planning (Critical Ratio scheduling)
- Resource allocation (which contract gets priority when?)
- Multi-line balancing

Strategy Hints:
- Prioritize Contract C first (earliest deadline)
- Use MES Critical Ratio scheduler (auto-prioritizes urgent work)
- Monitor contract dashboard constantly for deadline warnings
- Consider hiring temporary workers (cost vs penalty analysis)
```

**Challenge: "Perfect Delivery"**
```
Goal: Achieve flawless contract execution (zero defects, zero late penalties)
Contract: 500 engines over 30 days, weekly milestones
Twist: Random events occur (machine breakdowns, material delays)

Difficulty Tiers:
  Bronze: Complete contract, <3 defects → +1,100 CP
  Silver: Complete contract, 0 defects → +3,000 CP
  Gold: Complete contract, 0 defects, all milestones early → +10,000 CP

Key Skills Tested:
- Predictive maintenance (prevent breakdowns)
- Buffer management (absorb delays without impact)
- MES quality automation

Strategy Hints:
- Build safety margin (produce 110% of requirement, scrap the worst)
- Use predictive maintenance MES rules (schedule PM before failures)
- Maintain 2-day inventory buffer for each milestone
- Gold tier requires near-perfect execution (OEE >90%)
```

---

### 9.2.4 Resource Management Challenges

**Challenge: "Bootstrapper"**
```
Goal: Grow from startup to profitable in 60 days
Starting Conditions:
  - Cash: $25,000 (half normal)
  - 1 machine (CNC)
  - 2 workers
  - No active contracts

Target: $100,000 cash by day 60

Difficulty Tiers:
  Bronze: Reach $100k → +700 CP
  Silver: Reach $200k → +1,800 CP
  Gold: Reach $500k → +5,000 CP

Key Skills Tested:
- Financial management (when to invest vs save)
- Contract selection (high-margin vs high-volume)
- Growth timing (when to buy 2nd machine?)

Strategy Hints:
- Accept low-volume, high-margin contracts first (build cash)
- Delay 2nd machine purchase until cash flow stable
- Worker skill matters more than worker count early
- Silver/Gold tiers require perfect execution + some luck
```

**Challenge: "Efficiency Expert"**
```
Goal: Maximize profit per unit (minimize cost per engine)
Contract: Produce 200 engines, any time limit
Current Cost: $180/unit (baseline)
Target: Reduce cost to <$150/unit

Difficulty Tiers:
  Bronze: <$160/unit → +600 CP
  Silver: <$150/unit → +1,500 CP
  Gold: <$140/unit → +4,000 CP

Key Skills Tested:
- Waste elimination (reduce scrap to 0%)
- Cycle time reduction (faster = lower labor cost)
- Overhead allocation (better machine utilization)

Strategy Hints:
- Scrap is most expensive cost factor (each scrap = $200 lost)
- Worker efficiency: skilled workers cost more but produce faster
- MES optimization reduces cycle time by 10-15% (lower labor/unit)
- Material cost is fixed, focus on labor/overhead reduction
```

---

### 9.2.5 MES & Automation Challenges

**Challenge: "Code Master"**
```
Goal: Write MES block logic to handle complex production scenario
Scenario: 3 variants, each with different quality requirements
  - v1: Standard QC (5% sampling)
  - v2: Enhanced QC (10% sampling + dimensional check)
  - v3: Premium QC (20% sampling + dimensional + functional test)

Task: Create single MES rule that handles all 3 correctly

Difficulty Tiers:
  Bronze: Logic works, manual testing → +800 CP
  Silver: Logic works, passes simulation (0 errors in 100 parts) → +2,000 CP
  Gold: Logic optimized (minimal code, <5 blocks) → +6,000 CP

Key Skills Tested:
- MES block editor proficiency
- Conditional logic (IF-ELSE-SWITCH)
- Testing/debugging

Solution (Silver tier):
```
WHEN Part Arrives at QC_Station:
  GET Part.Version → var_version
  
  SWITCH var_version:
    CASE 1:
      SET QC.SampleRate = 0.05
      SET QC.Tests = ["Visual"]
    CASE 2:
      SET QC.SampleRate = 0.10
      SET QC.Tests = ["Visual", "Dimensional"]
    CASE 3:
      SET QC.SampleRate = 0.20
      SET QC.Tests = ["Visual", "Dimensional", "Functional"]
  END SWITCH
  
  EXECUTE QC
END
```
```

**Challenge: "Automation Architect"**
```
Goal: Build fully automated production line (no manual intervention for 8 hours)
Requirements:
  - MES handles all parameter changes
  - Auto-routing based on part type
  - Predictive maintenance prevents breakdowns
  - Worker assignments automatic

Difficulty Tiers:
  Bronze: 4 hours autonomous → +1,000 CP
  Silver: 8 hours autonomous → +3,000 CP
  Gold: 24 hours autonomous (full day) → +12,000 CP

Key Skills Tested:
- Advanced MES scripting
- Predictive analytics
- Error handling

Strategy Hints:
- Requires MES Tier 3 (text-based scripting) minimum for Gold
- Must implement error recovery (IF machine error THEN reroute to backup)
- Predictive maintenance crucial (monitor vibration, schedule PM automatically)
- Gold tier is endgame content (very difficult)
```

---

## 9.3 Random Events & Dynamic Challenges

**Event Types:**

### 9.3.1 Supply Chain Events

**Material Shortage**
```
Event: "Aluminum supplier delay - 3 days"
Impact: Can't produce aluminum parts for 3 days
Player Options:
  A) Wait (lose 3 days production)
  B) Emergency order from alt supplier (+50% cost, 1 day delivery)
  C) Switch to steel parts temporarily (requires ECO, quality risk)

Best Response: B if contract deadline tight, A if time available
Challenge: Deliver contracts despite disruption
Reward: +500 CP for on-time delivery despite event
```

**Price Spike**
```
Event: "Steel prices increased 30%"
Duration: 2 weeks
Impact: Material costs rise dramatically
Player Options:
  A) Absorb cost (lower margins)
  B) Renegotiate contracts (reputation risk)
  C) Switch to aluminum (engineering change required)

Challenge: Maintain profitability during crisis
Reward: +800 CP if profit margin stays >20%
```

---

### 9.3.2 Equipment Events

**Machine Breakdown**
```
Event: "CNC_02 spindle failure"
Cause: Random (or predictable if vibration ignored)
Downtime: 8 hours (emergency repair) or 2 hours (if spare parts stocked)
Player Options:
  A) Emergency repair ($5,000)
  B) Reroute production to other machines (if capacity available)
  C) Delay contracts (penalty)

Challenge: Minimize impact on contracts
Reward: +400 CP if zero contract delays
```

**Tool Recall**
```
Event: "End mill batch defective - replace all"
Impact: Must replace 10 tools immediately ($600)
Risk: If not replaced, 40% scrap rate
Player Options:
  A) Replace immediately (cost + 1 hour downtime)
  B) Continue production (gamble on scrap)
  C) Slow production to reduce stress on tools

Challenge: Make right decision under pressure
Reward: +300 CP if scrap <5% despite event
```

---

### 9.3.3 Workforce Events

**Worker Illness**
```
Event: "Worker_Sarah sick - 3 days"
Impact: Lose best machinist (Skill 95)
Player Options:
  A) Use backup worker (Skill 60, slower production)
  B) Hire temporary worker ($500/day, Skill 50)
  C) Delay non-critical work, focus resources

Challenge: Maintain quality without key worker
Reward: +250 CP if quality unchanged
```

**Union Negotiation** (Late-Game)
```
Event: "Workers demand 15% raise"
Context: Triggered after 6 months game time
Player Options:
  A) Accept (increase labor costs permanently)
  B) Negotiate (12% raise, improve morale)
  C) Refuse (morale drops 30%, productivity -15%)

Challenge: Balance cost vs productivity
Reward: +1,000 CP for maintaining profitability after event
```

---

### 9.3.4 Customer Events

**Rush Order**
```
Event: "Urgent order: 100 engines in 3 days (+50% premium)"
Normal time required: 5 days
Player Options:
  A) Accept (disrupt current schedule, overtime costs)
  B) Decline (lose opportunity)
  C) Negotiate (4 days, +30% premium)

Challenge: Reorganize production to meet rush order
Reward: +1,500 CP if delivered on time with quality
```

**Contract Cancellation**
```
Event: "Customer cancels 200-unit contract (halfway complete)"
Impact: 100 units WIP, no revenue
Player Options:
  A) Scrap WIP (lose investment)
  B) Find new customer for WIP units (marketing effort)
  C) Stockpile for future orders

Challenge: Minimize financial loss
Reward: +600 CP if loss <$10,000
```

---

## 9.4 Campaign Mode (Structured Progression)

**Story Arc:**

**Act 1: The Startup (Levels 1-8)**
```
Missions:
1. "First Contract" - Deliver 50 engines, any quality
2. "Growing Pains" - Hire 2nd worker, buy 2nd machine
3. "Quality Matters" - Achieve <3% scrap for 100 units
4. "Multi-Product" - Handle 2 variants simultaneously
5. "Reputation Building" - Complete 5 contracts successfully

Narrative: Alex Rivera takes over struggling factory, learns basics
```

**Act 2: The Expansion (Levels 9-16)**
```
Missions:
6. "MES Introduction" - Complete tutorial, create first block rule
7. "Efficiency Drive" - Achieve 75% OEE for 1 week
8. "R&D Investment" - Develop first in-house product
9. "Crisis Management" - Handle machine breakdown during contract
10. "Market Leader" - Outperform competitor (AI opponent)

Narrative: Factory grows, competition intensifies
```

**Act 3: The Mastery (Levels 17-25)**
```
Missions:
11. "Global Expansion" - Open 2nd factory location
12. "Automation Age" - Implement full MES automation
13. "Zero Defects" - Month-long perfect quality challenge
14. "Industry Leader" - 10 simultaneous contracts
15. "The Legacy" - Build factory worth $5,000,000

Narrative: Alex becomes industry titan, endgame unlocked
```

---

## 9.5 Sandbox Mode

**Freeplay Features:**

**Custom Scenarios:**
```
Player-Configurable Parameters:
- Starting cash: $10k - $500k
- Machine count: 1-20
- Worker skill levels: Fixed or random
- Contract difficulty: Easy/Normal/Hard/Nightmare
- Event frequency: Off/Rare/Normal/Frequent/Chaos
- Win condition: Custom (e.g., "$1M profit in 100 days")
```

**Mods & Community Content (Future):**
```
Steam Workshop Integration:
- Custom machines (community-created)
- New part types (beyond engines)
- MES template library (share automation scripts)
- Challenge scenarios (player-created)
- UI themes/skins
```

---

## 9.6 Leaderboards & Competitive Play

**Global Leaderboards:**

```
Categories:
1. Fastest 1000 Units Produced
2. Highest OEE (30-day average)
3. Lowest Cost per Unit
4. Most Profitable Month
5. Challenge Points Total

Filters: All-time / Monthly / Weekly
Platform: Steam leaderboards (auto-submit if player opts in)
```

**Daily Challenges:**
```
Rotating challenge each day:
- Fixed seed (everyone gets same scenario)
- 24-hour time limit to submit best score
- Rewards: Exclusive cosmetics, CP bonus

Example: "Produce 50 engines with these exact machines/workers/constraints"
```

---

## 9.7 Achievements

**Tiered Achievements:**

**Production Achievements:**
```
🥉 Assembly Line Worker: Produce 100 engines
🥈 Factory Foreman: Produce 1,000 engines
🥇 Industry Titan: Produce 10,000 engines
💎 Manufacturing Legend: Produce 100,000 engines
```

**Quality Achievements:**
```
🥉 Quality Conscious: <2% scrap for 100 units
🥈 Six Sigma Green Belt: <1% scrap for 500 units
🥇 Six Sigma Black Belt: <0.5% scrap for 1,000 units
💎 Zero Defect Master: 0% scrap for 1,000 units
```

**MES Achievements:**
```
🥉 Script Kiddie: Create first MES rule
🥈 Automation Engineer: 10 MES rules active
🥇 Code Master: Write text-based MES script
💎 AI Whisperer: Use AI-assisted MES optimization
```

**Speed Achievements:**
```
⚡ Speed Demon: Produce 10 units in 1 hour
⚡⚡ Lightning Production: Produce 100 units in 1 day
⚡⚡⚡ Supersonic Factory: Produce 1,000 units in 1 week
```

**Mastery Achievements:**
```
🏆 Triple Crown: Win 3 Gold-tier challenges
🏆🏆 Master of All Trades: Win all challenges (Bronze+)
🏆🏆🏆 Perfectionist: Win all challenges (Gold tier)
👑 Ultimate Engineer: Unlock all techs, max level, $10M net worth
```

**Secret/Easter Egg Achievements:**
```
🎂 Birthday Party: Play on game's release anniversary
🐛 Bug Hunter: Discover & report 10 bugs (Beta only)
📚 Lore Master: Read all tutorial texts
🎨 Fashionista: Unlock all UI themes
```

---

## 9.8 Challenge Point (CP) Shop

**What CP Buys:**

**Exclusive Machines:**
```
🏭 Quantum CNC (50,000 CP)
   - 2× speed of normal CNC
   - Perfect quality (0% scrap)
   - Endgame prestige item

🔩 Auto-Nutrunner (30,000 CP)
   - Fully automated torque application
   - Zero worker required
   - Unlocks "lights-out" manufacturing
```

**MES Templates (Pre-Built Rules):**
```
📜 Master Mixed-Model Script (5,000 CP)
   - Handles up to 10 variants flawlessly
   - Community-voted best template

📜 Predictive Perfection (8,000 CP)
   - AI-level predictive maintenance
   - Prevents 95% of breakdowns
```

**Cosmetic Unlocks:**
```
🎨 UI Themes: Cyberpunk, Retro, Minimalist (2,000 CP each)
🎵 Music Packs: Jazz Factory, Synthwave, Lo-Fi Beats (1,500 CP)
🏭 Factory Skins: Chrome, Steampunk, Neon (3,000 CP each)
```

**Gameplay Boosts (Optional, Controversial):**
```
⚠️ Design Note: Consider if these make game "pay-to-win" with CP
These should probably be cosmetic-only to maintain competitive balance

Possible (if implemented):
💰 Capital Injection: +$50k cash (10,000 CP) - One-time use
👷 Expert Hire: Instant Skill 90 worker (8,000 CP)
🔧 Perfect Maintenance: 1-month zero breakdowns (6,000 CP)

Alternative: Make these available ONLY in Sandbox mode
```

---

## 9.9 Difficulty Modifiers (Sandbox)

**Hardcore Mode:**
```
Modifiers:
- Permadeath: Bankruptcy ends game (no reloading)
- Realistic time: No pause, 1x speed only
- Random events: 3× frequency
- Contracts: Strict penalties, no extensions
- Workers: Can quit permanently if morale <30

Reward: 2× XP and CP for all actions
Achievement: "Hardcore Survivor" (complete 30 days)
```

**Easy Mode:**
```
Modifiers:
- Starting cash: 2× normal
- Contract deadlines: +50% more time
- Random events: Disabled
- Scrap rate: -50% (quality easier)
- Tutorial: Expanded hints, auto-suggestions

Use Case: New players, casual experience, learning
Penalty: -50% XP and CP earnings
```

**Custom Difficulty Sliders:**
```
Player adjusts:
- Contract difficulty: 0.5× to 3×
- Event frequency: 0× to 5×
- Economic pressure: Easy/Normal/Hard
- Worker loyalty: Stable/Normal/Volatile
- Starting resources: Poor/Normal/Rich

Game calculates XP/CP multiplier based on settings
Encourages experimentation without penalty
```

---

## 9.10 Tutorial & Learning Challenges

**Integrated Tutorials (Not Separate Mode):**

**Tutorial 1: "Your First Engine"**
```
Steps:
1. Click CNC machine → observe it machining
2. Worker auto-assigned (shows worker mechanics)
3. Part completes → moves to Assembly
4. Assembly worker tightens bolts
5. Part goes to QC → passes
6. First engine complete! (+100 XP)

Learning: Basic production flow, no player input required
Duration: 2 minutes
```

**Tutorial 2: "Making it Better"**
```
Steps:
1. Challenge: Produce 10 engines
2. Player clicks "Hire Worker" (guided)
3. Player assigns worker to 2nd machine
4. Production speeds up (visible improvement)
5. Complete 10 engines faster

Learning: Workers matter, parallelization helps
Reward: +200 XP, unlock worker training
```

**Tutorial 3: "Quality Control"**
```
Steps:
1. Intentional: Machine produces defective part
2. QC catches it, part scrapped
3. Tutorial explains: "Scrap costs $200, fix the issue"
4. Player adjusts machine parameter (guided)
5. Next parts pass QC

Learning: Quality matters, parameters affect outcomes
Reward: +300 XP, unlock MES presets
```

**Tutorial 4: "Your First Contract"**
```
Steps:
1. Contract offered: 50 engines, 3 days
2. Player accepts
3. Production dashboard shows progress (15/50)
4. Player must plan to meet deadline
5. Delivery on-time → bonus payment

Learning: Contracts = goals, time pressure, rewards
Reward: +500 XP, unlock contract negotiation
```

**Tutorial 5: "Automation Basics"**
```
Steps:
1. Show MES panel (first time)
2. Guided: Create simple MES rule (preset selection)
3. MES rule applies → production improves
4. Tutorial: "This is automation - optional but powerful"

Learning: MES exists, is beneficial, not required
Reward: +400 XP, unlock MES Block Editor
```

---

**End of Section 9 - Challenges & Advanced Gameplay**

---

# 10. GAME PROGRESSION & ENDGAME

## 10.1 Progression Overview

**Core Philosophy:** Players should feel constant progress across multiple dimensions simultaneously.

**Progression Dimensions:**

1. **Player Level** (XP-based): 1-25
2. **Company Size** (machines, workers, factories)
3. **Technology Unlocks** (research tree)
4. **Contract Complexity** (simple → multi-product → global)
5. **Automation Mastery** (manual → MES blocks → AI-assisted)
6. **Financial Growth** ($50k → $10M+ net worth)

**Pacing Design:**
- **Hours 0-5:** Fast progression (frequent unlocks, dopamine hits)
- **Hours 5-20:** Moderate pace (learning systems deeply)
- **Hours 20-50:** Slower but meaningful (mastery-focused)
- **Hours 50+:** Endgame (prestige, perfection, sandbox)

---

## 10.2 Early Game (Levels 1-8, Hours 0-10)

**Starting State:**
```
Assets:
- Cash: $50,000
- Machines: CNC_01, Lathe_01 (pre-placed)
- Workers: 2 (Skill 60 generalists)
- Contracts: 1 tutorial contract active
- Tech: Tier 0 (no unlocks)

Immediate Goals:
- Complete tutorial contract (50 engines)
- Learn basic production flow
- Hire 1st additional worker
- Unlock MES GUI presets
```

**Key Milestones:**

**Level 2 (1,000 XP)**
```
Unlock: Worker Training
Tutorial: "Train workers to improve efficiency"
Player Action: Train 1 worker in Machining specialty
Result: Visible efficiency gain on CNC jobs
Reward: "Invested in People" achievement
```

**Level 3 (2,500 XP total)**
```
Unlock: MES GUI Presets
Tutorial: "Automation 101 - Use MES presets for better quality"
Player Action: Apply "High Precision" preset to v2 engine production
Result: Scrap rate drops 5-8%
Reward: "Automation Apprentice" achievement
```

**Level 5 (6,000 XP total)**
```
Unlock: Multi-Product Capability
Tutorial: "Handle 2 engine variants"
Player Action: Accept contract requiring both v1 and v2
Challenge: Must manage different parameters
Reward: +$15,000 contract bonus, "Diverse Portfolio" achievement
```

**Level 8 (12,000 XP total)**
```
Unlock: MES Block Editor (Tier 2)
Tutorial: "Create your first automation rule"
Player Action: Build simple IF-THEN rule for variant switching
Result: Enables mixed-model production
Reward: "Code Novice" achievement, +1,000 CP
Milestone: "Early Game Complete" checkpoint
```

**Early Game Pacing:**
```
Leveling Speed:
- Level 1 → 2: ~30 minutes (tutorial fast)
- Level 2 → 3: ~45 minutes
- Level 3 → 5: ~2 hours
- Level 5 → 8: ~4 hours

Player should feel: "I'm learning fast, progress feels good"
```

**Early Game Challenges:**
```
Common Player Struggles:
1. Not understanding worker assignment (Tutorial: highlight this)
2. Ignoring scrap (Tutorial: show cost impact)
3. Accepting too many contracts (Tutorial: warn about capacity)

Teaching Moments:
- First scrap event → explain quality matters
- First late delivery → explain planning matters
- First worker fatigue → explain shift management
```

---

## 10.3 Mid Game (Levels 9-16, Hours 10-40)

**Entry State:**
```
Assets:
- Cash: ~$200,000
- Machines: 4-6 (CNC ×2, Lathe, Assembly, QC)
- Workers: 5-8 (mix of specialists)
- Contracts: 2-3 active simultaneously
- Tech: Tier 1-2 unlocks (MES blocks, some upgrades)

Goals:
- Scale production (handle 500+ units/week)
- Master MES automation
- Develop first in-house product
- Achieve 80%+ OEE consistently
```

**Key Milestones:**

**Level 10 (20,000 XP total)**
```
Unlock: R&D Department
Tutorial: "Develop your own products for higher margins"
Player Action: Assign 1 engineer to R&D project
Project: 2-week timeline, $10k investment
Result: Unlocks in-house engine variant (higher profit margin)
Reward: "Innovator" achievement
```

**Level 12 (30,000 XP total)**
```
Unlock: Advanced Scheduling (Critical Ratio, EDD)
Tutorial: "Optimize contract priorities automatically"
Player Action: Enable Critical Ratio scheduler in MES
Result: Reduced late deliveries by 40%
Reward: "Time Master" achievement
```

**Level 14 (45,000 XP total)**
```
Unlock: Multi-Line Production
Tutorial: "Run 2+ production lines simultaneously"
Player Action: Build 2nd complete production line
Challenge: Balance workload between lines
Result: Throughput doubles (if managed well)
Reward: "Expansion Expert" achievement, +3,000 CP
```

**Level 16 (65,000 XP total)**
```
Unlock: AGVs (Automated Guided Vehicles)
Tutorial: "Automate material transport"
Player Action: Purchase 2 AGVs ($45k each)
Result: Workers freed from transport, focus on skilled tasks
Benefit: +15% worker efficiency, enables dynamic routing
Reward: "Automation Architect" achievement
Milestone: "Mid Game Complete" checkpoint
```

**Mid Game Pacing:**
```
Leveling Speed:
- Level 9 → 10: ~3 hours
- Level 10 → 12: ~5 hours
- Level 12 → 14: ~6 hours
- Level 14 → 16: ~8 hours
Total: ~22 hours for mid-game

Player should feel: "I'm mastering systems, building empire"
```

**Mid Game Complexity Ramp:**
```
New Challenges Introduced:
1. Multi-contract juggling (3+ simultaneous)
2. ECO events (mid-production spec changes)
3. Market fluctuations (material price spikes)
4. Worker morale management (prevent turnover)
5. Competitor pressure (AI opponents unlock at L12)

Strategic Depth:
- MES optimization becomes critical (manual too slow)
- Financial planning matters (capex vs opex decisions)
- Tech tree choices diverge (quality vs volume vs automation paths)
```

---

## 10.4 Late Game (Levels 17-24, Hours 40-100)

**Entry State:**
```
Assets:
- Cash: $1,000,000+
- Machines: 15-30 (multiple complete lines)
- Workers: 20-40 (highly specialized teams)
- Contracts: 5-10 active, high complexity
- Tech: Tier 3-4 unlocks (AI, digital twin, predictive)
- Factories: 1-2 locations

Goals:
- Optimize for efficiency (90%+ OEE)
- Handle global contracts
- Build manufacturing empire
- Achieve financial independence ($5M+ net worth)
```

**Key Milestones:**

**Level 18 (95,000 XP total)**
```
Unlock: Predictive Maintenance AI
Tutorial: "Prevent breakdowns before they happen"
Player Action: Enable predictive analytics on all machines
Result: Unplanned downtime reduced 80%
Data: Vibration/temperature sensors predict failures 3-5 days early
Reward: "Fortune Teller" achievement, +5,000 CP
```

**Level 20 (130,000 XP total)**
```
Unlock: Digital Twin Simulation
Tutorial: "Test production changes risk-free"
Player Action: Run simulation of new contract scenario
Result: Identify bottleneck before it occurs in reality
Use Case: "What if we double production? Where will we fail?"
Reward: "Simulation Master" achievement
```

**Level 22 (170,000 XP total)**
```
Unlock: AI-Assisted MES Optimization
Tutorial: "Let AI suggest optimal parameters"
Player Action: Enable AI on CNC line
Result: AI finds 7% efficiency improvement player missed
Note: Player retains final decision (AI suggests, doesn't auto-apply)
Reward: "Human-AI Collaboration" achievement, +8,000 CP
```

**Level 24 (220,000 XP total)**
```
Unlock: Global Expansion (2nd Factory)
Tutorial: "Open facility in new region"
Player Action: Choose location (Asia/Europe/Americas)
Challenge: Different regulations, labor costs, material prices
Result: 2× production capacity, strategic complexity
Reward: "Global Titan" achievement
Milestone: "Late Game Complete" checkpoint
```

**Late Game Pacing:**
```
Leveling Speed:
- Level 17 → 18: ~10 hours
- Level 18 → 20: ~15 hours
- Level 20 → 22: ~20 hours
- Level 22 → 24: ~25 hours
Total: ~70 hours for late-game

Player should feel: "I'm a manufacturing genius, optimizing perfection"
```

**Late Game Focus:**
```
Shift from Growth to Optimization:
- No longer adding machines constantly
- Focus: Squeeze every % of efficiency
- Challenges: Increasingly difficult contracts
- Motivation: Perfectionism, leaderboards, mastery

Example Late-Game Session:
"Today I'll optimize my CNC line from 88% OEE to 91%"
- Analyze data (SPC charts, Pareto)
- Adjust MES rules (fine-tune parameters)
- Test in digital twin
- Deploy to production
- Monitor results
= Deeply satisfying iterative improvement
```

---

## 10.5 Endgame (Level 25, Hours 100+)

**Entry State:**
```
Assets:
- Cash: $10,000,000+ (or $50M+ for completionists)
- Machines: 50-100+ (multiple factories)
- Workers: 100+ (global workforce)
- Contracts: Exclusive high-value deals
- Tech: All Tier 5 unlocks
- OEE: 95%+ factory-wide average

Status: Manufacturing empire established
```

**Level 25 (300,000 XP total)**
```
Unlock: All features available
Title: "Manufacturing Legend"
Endgame Content Unlocked:
- Prestige system (optional reset with bonuses)
- Quantum Factory (experimental Tier 6 tech)
- Challenge Mode+ (nightmare difficulty)
- Creative Sandbox (unlimited resources)
```

**Endgame Activities:**

### 10.5.1 Prestige System (Optional Reset)

```
Concept: "New Game+" with permanent bonuses

How It Works:
1. Player chooses to "Prestige" (restart from Level 1)
2. Loses all assets (cash, machines, workers)
3. Keeps: Knowledge (tech tree visible), Challenge Points, achievements
4. Gains: Prestige Stars + permanent bonuses

Prestige Bonuses (Cumulative):
★ Prestige 1: +10% XP gain, +5% starting cash
★★ Prestige 2: +15% XP, +10% cash, unlock special "Veteran" MES templates
★★★ Prestige 3: +20% XP, +15% cash, unique "Prestige" factory skin
★★★★ Prestige 4: +25% XP, +20% cash, exclusive "Master" achievement
★★★★★ Prestige 5: +30% XP, +25% cash, "Immortal Legend" title

Goal: Speed-run to Level 25 faster each time
Leaderboard: Fastest time to Level 25 (Prestige 5)
```

### 10.5.2 Quantum Factory (Experimental)

```
Tier 6 Tech (Endgame Only):

Quantum CNC:
- Cost: 100,000 CP + $5,000,000
- Speed: 5× faster than normal CNC
- Quality: 0% scrap (perfect every time)
- Limitation: Only 1 allowed per save (prestige item)

Quantum Nutrunner:
- Cost: 80,000 CP + $3,000,000
- Torque: Perfect every bolt (zero failures)
- Speed: Instant tightening (no time cost)
- Limitation: Only 1 allowed

Purpose: Ultimate prestige flex item
Balance: So expensive only endgame players afford
Not required: Game beatable without these
```

### 10.5.3 Challenge Mode+ (Nightmare Difficulty)

```
Unlock: After reaching Level 25

New Challenges:
- "1000 Units in 24 Hours" (previously impossible)
- "5 Variants Simultaneously with 0% Scrap"
- "Survive Global Economic Crisis" (all costs double for 30 days)
- "Perfect Factory" (95% OEE for 90 continuous days)

Rewards: Exclusive cosmetics, ultra-rare CP bonuses (50k+)
Leaderboard: Global rankings for each challenge
```

### 10.5.4 Creative Sandbox Mode

```
Unlock: Level 25 + Complete campaign

Features:
- Infinite cash (toggle)
- All machines unlocked
- No contract deadlines (optional)
- Custom scenario editor
- Share scenarios to Workshop

Use Cases:
- Build dream factory (no economic pressure)
- Test extreme setups (100 AGVs!)
- Create challenge maps for community
- Educational tool (teach real manufacturing concepts)
```

### 10.5.5 Modding Support (Future)

```
API Exposure (Post-Launch):
- Custom machine definitions (JSON)
- Custom part types
- MES scripting extensions (Lua plugins)
- UI themes (CSS-like)
- Sound packs

Community Content:
- Steam Workshop integration
- Featured mods by developers
- Monthly "Mod of the Month" spotlight
- Potential: User-created industries (beyond engines)
```

---

## 10.6 Progression Pacing Analysis

**XP Curve Design:**

```
Level Progression Table:

| Level | XP Required | XP Total | Hours (Avg) | Milestone |
|-------|-------------|----------|-------------|-----------|
| 1     | 0           | 0        | 0           | Start |
| 2     | 1,000       | 1,000    | 0.5         | First unlock |
| 5     | 4,000       | 6,000    | 3           | Multi-product |
| 8     | 6,000       | 12,000   | 6           | MES blocks |
| 10    | 8,000       | 20,000   | 10          | R&D |
| 12    | 10,000      | 30,000   | 15          | Scheduling |
| 15    | 15,000      | 60,000   | 25          | Advanced |
| 18    | 20,000      | 95,000   | 40          | Predictive |
| 20    | 35,000      | 130,000  | 55          | Digital twin |
| 22    | 40,000      | 170,000  | 70          | AI assist |
| 25    | 130,000     | 300,000  | 100+        | Endgame |

Curve Shape: Exponential but not punishing
Early: Fast (dopamine hits)
Mid: Moderate (learning depth)
Late: Slow but meaningful (mastery)
```

**Financial Progression:**

```
Net Worth Benchmarks:

| Level | Target Net Worth | Typical Assets |
|-------|------------------|----------------|
| 1     | $50,000          | 2 machines, 2 workers |
| 5     | $150,000         | 4 machines, 5 workers |
| 10    | $500,000         | 8 machines, 12 workers, R&D team |
| 15    | $2,000,000       | 15 machines, 25 workers, 2 lines |
| 20    | $5,000,000       | 30 machines, 50 workers, AGVs |
| 25    | $10,000,000+     | Multiple factories, global empire |

Growth Rate: ~10× every 10 levels (aggressive but achievable)
```

---

## 10.7 Player Retention Mechanics

**Daily Engagement:**

```
Daily Bonus:
- First login each day: +500 XP, +$5,000
- Streak bonuses: +10% per consecutive day (cap: 30 days)
- Day 7 streak: +5,000 XP, +$50,000, +1,000 CP
- Day 30 streak: Special reward (rare MES template)

Daily Challenge:
- Rotating challenge (changes 00:00 UTC)
- Complete for: +1,500 XP, +500-2,000 CP
- Leaderboard: Top 100 globally get bonus CP
```

**Weekly Goals:**

```
Auto-Generated Weekly Objectives:
- Produce 500 units (scaled to player level)
- Achieve 85% OEE for 3 days
- Complete 2 contracts perfectly
- Train 1 worker to next skill level

Reward: +10,000 XP, +3,000 CP, random tech unlock discount (20% off)
```

**Monthly Events:**

```
"Manufacturing Month" Events:
- Special event contracts (2× rewards)
- Community goals (all players contribute)
  Example: "Produce 1,000,000 engines globally → unlock special cosmetic for all"
- Developer challenges (beat dev's factory setup)
- New content drop (machines, challenges, features)
```

---

## 10.8 Alt-Win Conditions (Optional Goals)

**Financial Victory:**
```
Goal: Achieve $50,000,000 net worth
Difficulty: Hard (requires perfect optimization)
Reward: "Tycoon Supreme" achievement, golden factory skin
Estimated Time: 150-200 hours
```

**Quality Perfectionist:**
```
Goal: 0% scrap for 10,000 consecutive units
Difficulty: Extreme (requires flawless MES + luck)
Reward: "Zero Defect Legend" achievement, platinum nutrunner cosmetic
Estimated Time: 100+ hours of perfect play
```

**Speed Run:**
```
Goal: Reach Level 25 in <50 hours (game time)
Difficulty: Expert (requires deep knowledge)
Reward: "Speedrunner" achievement, leaderboard entry
Category: Any% / 100% / Prestige speedruns
```

**Automation Master:**
```
Goal: 48 hours fully autonomous production (no player input)
Difficulty: Very Hard (MES scripting expertise required)
Reward: "Lights-Out Legend" achievement, AI assistant cosmetic
Verification: Game records input events, must be zero
```

**Challenger:**
```
Goal: Complete all challenges at Gold tier
Difficulty: Insane (comprehensive mastery)
Reward: "Ultimate Champion" achievement, 100,000 CP, exclusive title
Estimated Time: 200+ hours
```

---

## 10.9 Post-Endgame Content Roadmap (Future Updates)

**Planned Expansions:**

**Year 1 Post-Launch:**
```
Q1: Quality of Life Update
- UI improvements based on feedback
- Balance tweaks
- Bug fixes
- New MES templates

Q2: New Industry Expansion
- New product type: Transmissions
- 5 new machines
- New tech tree branch

Q3: Multiplayer Alpha
- Co-op factories (2 players)
- Shared contracts
- Competitive leaderboards v2

Q4: Modding Tools Release
- Official modding SDK
- Steam Workshop integration
- Community showcase
```

**Year 2 (If Successful):**
```
- Full multiplayer (4 players)
- New regions (South America, Africa)
- Advanced automation (robot arms)
- VR mode (experimental)
```

---

## 10.10 Endgame Player Testimonials (Target Experience)

**What Endgame Should Feel Like:**

```
Player Quote 1 (Imagined):
"I've spent 150 hours building the perfect factory. Every machine 
optimized, every MES rule polished. My OEE is 96.3% and I'm still 
finding 0.1% improvements. This game respects my time and intelligence."

Player Quote 2:
"The prestige system made me want to start over! Now I'm speedrunning 
to Level 25 with all my knowledge from run 1. Currently at Level 18 
after just 40 hours. Going for sub-50 hour completion!"

Player Quote 3:
"I'm a real-world manufacturing engineer, and this game taught me 
concepts I use at work now. The MES system is shockingly accurate. 
10/10 for educational value + fun."
```

**Design Success Metrics:**

```
Target Stats (Post-Launch):
- Average playtime: 60 hours (50th percentile)
- Hardcore players: 200+ hours (90th percentile)
- Completion rate (L25): 15-20% of players
- Prestige rate: 5% of players
- Daily active users (30 days post): 30% of peak
- Steam review score: 85%+ positive
```

---

**End of Section 10 - Game Progression & Endgame**

---

# 11. COMPLETE GAME FLOW & EVENT SYSTEM

## 11.1 Master Game Loop (All Systems Integrated)

**The Complete Flow:**

```
┌─────────────────────────────────────────────────────────┐
│ 1. PLAYER PLANNING PHASE (Pre-Production)              │
├─────────────────────────────────────────────────────────┤
│ • Review active contracts (deadlines, requirements)     │
│ • Check resources (cash, materials, workers, machines)  │
│ • Allocate production (which lines make which products) │
│ • Set/adjust MES rules (if using automation)            │
│ • Schedule shifts and worker assignments                │
│ • Review tech tree (decide next unlock)                 │
│                                                         │
│ → OUTPUT: Production plan ready to execute             │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 2. PRODUCTION EXECUTION PHASE (Active)                  │
├─────────────────────────────────────────────────────────┤
│ • Machines activate (OPC-UA commands sent)              │
│ • Workers execute tasks (based on assignments)          │
│ • Parts flow through stations (conveyors/AGVs)          │
│ • MES rules apply in real-time (parameter adjustments)  │
│ • Data collected (cycle times, quality, telemetry)      │
│                                                         │
│ PLAYER ACTIONS DURING:                                  │
│ • Monitor dashboards (KPIs, alerts, progress)           │
│ • React to events (breakdowns, delays, QC failures)     │
│ • Adjust on-the-fly (pause, change parameters, reroute) │
│                                                         │
│ → OUTPUT: Parts produced, data logged                  │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 3. QUALITY CONTROL PHASE                                │
├─────────────────────────────────────────────────────────┤
│ • QC station inspects parts (dimensional, visual, test) │
│ • MES records results (pass/fail, measurements)         │
│ • Failed parts → rework or scrap (cost impact)          │
│ • Passed parts → genealogy updated, ready for delivery  │
│ • SPC analysis (trend detection, alerts if drifting)    │
│                                                         │
│ → OUTPUT: Good parts identified, defects handled       │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 4. CONTRACT FULFILLMENT & DELIVERY                      │
├─────────────────────────────────────────────────────────┤
│ • Good parts allocated to contracts                     │
│ • Contract progress updated (145/200 complete)          │
│ • Delivery deadlines checked                            │
│   - On-time: Bonus payment                              │
│   - Late: Penalty applied                               │
│ • Quality metrics evaluated                             │
│   - Below threshold: Additional penalties               │
│   - Perfect quality: Bonus                              │
│                                                         │
│ → OUTPUT: Revenue collected, reputation updated        │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 5. FINANCIAL UPDATE & RESOURCE MANAGEMENT               │
├─────────────────────────────────────────────────────────┤
│ • Revenue added to cash                                 │
│ • Costs deducted:                                       │
│   - Materials consumed                                  │
│   - Worker salaries (per shift/week)                    │
│   - Machine maintenance                                 │
│   - Overhead (utilities, rent)                          │
│ • P&L statement updated                                 │
│ • Material inventory depleted                           │
│ • Trigger: Auto-reorder if inventory < threshold        │
│                                                         │
│ → OUTPUT: Updated financials, purchase orders sent     │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 6. PROGRESSION & REWARDS                                │
├─────────────────────────────────────────────────────────┤
│ • XP calculated (production + contracts + challenges)   │
│ • Level up check (unlock new features if leveled)       │
│ • Challenge Points awarded (if applicable)              │
│ • Achievements checked (did player meet criteria?)      │
│ • Reputation updated (customer satisfaction)            │
│                                                         │
│ IF LEVEL UP:                                            │
│   - Show level up screen                                │
│   - Unlock notification (new tech/feature available)    │
│   - Update tech tree (new nodes visible)                │
│                                                         │
│ → OUTPUT: Player progresses, new options available     │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 7. EVENTS & CHALLENGES                                  │
├─────────────────────────────────────────────────────────┤
│ • Random event check (probability-based)                │
│   - Machine breakdown                                   │
│   - Material delay                                      │
│   - Rush order                                          │
│   - Worker illness                                      │
│                                                         │
│ • Triggered events (condition-based)                    │
│   - Contract deadline approaching (< 24 hours)          │
│   - Cash low (< $10k)                                   │
│   - QC failure spike (scrap > 5%)                       │
│   - Tool wear critical (> 85%)                          │
│                                                         │
│ • Challenge opportunities presented                     │
│   - New challenge available notification                │
│   - Daily challenge refresh                             │
│                                                         │
│ → OUTPUT: Player faces new decisions/problems          │
└─────────────────────────────────────────────────────────┘
                            ↓
┌─────────────────────────────────────────────────────────┐
│ 8. PLANNING & OPTIMIZATION PHASE                        │
├─────────────────────────────────────────────────────────┤
│ • Review analytics (what worked, what didn't)           │
│ • Identify bottlenecks (heatmap analysis)               │
│ • Plan improvements:                                    │
│   - Hire/train workers                                  │
│   - Buy/upgrade machines                                │
│   - Research new tech                                   │
│   - Optimize MES rules                                  │
│   - Adjust factory layout                               │
│                                                         │
│ • Accept new contracts (if capacity available)          │
│ • Initiate R&D projects (if desired)                    │
│                                                         │
│ → OUTPUT: Strategic decisions made, ready for next cycle│
└─────────────────────────────────────────────────────────┘
                            ↓
                     [LOOP REPEATS]
```

**Loop Timing:**

- **One complete cycle:** 10-30 minutes (game time: hours to days)
- **Early game:** Player involved in each phase actively
- **Late game:** MES automation handles phases 2-4, player focuses on strategy (1, 8)

---

## 11.2 Event System Architecture

**Event Types:**

### 11.2.1 Random Events (Probability-Based)

**Event Probability Table:**

| Event | Base Probability | Modifiers | Frequency |
|-------|------------------|-----------|-----------|
| Machine Breakdown | 2% per day | -50% if predictive maintenance active | ~1 per 50 days |
| Material Delay | 3% per shipment | +50% if single supplier | ~1 per 30 shipments |
| Worker Illness | 1% per worker per week | -30% if morale >80 | Rare |
| Tool Defect Batch | 0.5% per tool order | None | Very rare |
| Rush Order | 5% per week | +20% if reputation >80 | ~1 per 20 weeks |
| Price Spike | 1% per month | +50% if economic crisis active | ~1 per 100 months |

**Event Generation Logic:**

```
EVERY GAME DAY:
  FOR EACH event_type IN random_events:
    roll = random(0.0, 1.0)
    adjusted_prob = event_type.base_prob × modifiers
    
    IF roll < adjusted_prob THEN
      TRIGGER event_type
      LOG event in event_log
      NOTIFY player
      APPLY consequences
    END
  END
END

Modifier Examples:
- Predictive maintenance: -50% breakdown chance
- High morale: -30% worker illness
- Multiple suppliers: -50% delay chance
- High reputation: +20% rush order chance
```

---

### 11.2.2 Triggered Events (Condition-Based)

**Alert Thresholds:**

```
Cash Low Warning:
  IF cash < $10,000 AND weekly_burn_rate > cash THEN
    TRIGGER "Cash Crisis Imminent" alert
    SUGGEST actions: Take loan, delay purchases, aggressive contract
  END

Contract Deadline Warning:
  IF contract.deadline - current_time < 24 hours THEN
    TRIGGER "Deadline Approaching" alert
    PRIORITY level: HIGH
    SUGGEST: Prioritize this contract in scheduler
  END

Quality Crisis:
  IF recent_scrap_rate > 5% FOR 100 consecutive parts THEN
    TRIGGER "Quality Emergency" event
    SUGGEST: Stop production, investigate root cause, retrain workers
  END

Tool Wear Critical:
  IF tool.wear > 85% AND tool_replacement_not_scheduled THEN
    TRIGGER "Tool Replacement Urgent" alert
    AUTO-SUGGEST: Schedule immediate replacement
  END

Worker Morale Crisis:
  IF average_worker_morale < 40 THEN
    TRIGGER "Worker Unrest" event
    CONSEQUENCE: -20% productivity until resolved
    SUGGEST: Raise wages, improve conditions, hire manager
  END
```

---

### 11.2.3 Narrative Events (Story-Driven)

**Campaign Events (Level-Based):**

```
Level 5: "First Competitor"
  Narrative: "Local competitor challenges your quality standards"
  Mechanic: AI opponent introduced, benchmarking begins
  Player Choice: Compete on quality OR price OR speed
  Outcome: Sets strategic direction for player

Level 10: "The Investor"
  Narrative: "Venture capitalist offers $500k investment for 20% equity"
  Player Choice:
    A) Accept: +$500k cash, -20% future profits (permanent)
    B) Decline: Keep independence, slower growth
  Outcome: Major strategic fork

Level 15: "Union Negotiations"
  Narrative: "Workers unionize, demand better conditions"
  Player Choice:
    A) Accept demands (+15% wages, +morale)
    B) Negotiate (12% wages, neutral morale)
    C) Refuse (-30 morale, risk strike)
  Outcome: Defines labor relations for endgame

Level 20: "Global Opportunity"
  Narrative: "International corporation offers partnership"
  Unlock: 2nd factory in new region
  Choice: Asia (low labor cost) vs Europe (high skill) vs Americas (shipping advantages)
  Outcome: Sets expansion strategy
```

---

## 11.3 Event Response System

**Player Decision Framework:**

```
EVENT OCCURS:
  1. Pause game (optional, player can disable)
  2. Display event panel with:
     - Event description
     - Consequences if ignored
     - Available options (2-4 choices)
     - Expected outcomes per choice
     - Cost/benefit analysis (if applicable)
  3. Player selects option OR dismisses
  4. Game applies consequences
  5. Log decision in event history
  6. Resume gameplay

Example Event Panel:
┌────────────────────────────────────────────────────┐
│ ⚠️ EVENT: Machine Breakdown                        │
├────────────────────────────────────────────────────┤
│ CNC_02 spindle bearing failure                    │
│ Detected: Day 45, 14:32                           │
│                                                    │
│ IMPACT IF IGNORED:                                 │
│ • 8-12 hours downtime (emergency repair)           │
│ • $5,000 emergency repair cost                     │
│ • 60-80 parts lost production                      │
│ • Contract C may be delayed (penalty: $3,000)      │
│                                                    │
│ OPTIONS:                                           │
│                                                    │
│ A) Emergency Repair Now [$5,000, 8 hrs downtime]   │
│    Pro: Fixed fastest                              │
│    Con: Expensive, disrupts Contract C             │
│                                                    │
│ B) Use Spare Parts [$1,200, 2 hrs downtime]        │
│    Pro: Fast, cheap (spare parts stocked)          │
│    Con: Depletes spare inventory                   │
│    Available: YES (stocked 1 spare)                │
│                                                    │
│ C) Reroute to CNC_01 [No cost, slower]             │
│    Pro: Zero downtime on production                │
│    Con: CNC_01 overloaded (slower cycles +20%)     │
│    Impact: Contract C still deliverable            │
│                                                    │
│ D) Delay & Negotiate [$0, renegotiate deadline]    │
│    Pro: No immediate cost                          │
│    Con: Reputation hit (-5), future contracts     │
│    Contract owner may refuse                       │
│                                                    │
│ RECOMMENDATION (MES AI): Option B                  │
│ Reasoning: Spare available, minimal disruption     │
│                                                    │
│ [Select Option] [View Machine Details] [Cancel]    │
└────────────────────────────────────────────────────┘
```

---

## 11.4 Time Management & Game Speed

**Game Speed Controls:**

| Speed | Real Time | Game Time | Use Case |
|-------|-----------|-----------|----------|
| Pause (⏸) | 0× | Frozen | Planning, reading, decision-making |
| 1× (▶) | 1 sec | 1 min game time | Normal play, monitoring closely |
| 2× (▶▶) | 1 sec | 2 min game time | Experienced players, stable production |
| 5× (▶▶▶) | 1 sec | 5 min game time | Advanced players, automation active |

**Auto-Pause Triggers (Player-Configurable):**

```
Settings → Auto-Pause Conditions:
☑ Critical alerts (machine breakdown, contract failure)
☑ Contract completed
☐ Level up
☑ Event requiring decision
☐ Worker needs assignment
☑ Cash below threshold ($10k default)
☐ Any alert
```

**Time Acceleration Limits:**

```
Speed caps based on complexity:
- 1-3 machines: Max 5× speed
- 4-10 machines: Max 5× (if OEE >75%) else max 2×
- 11+ machines: Max 2× (too complex for 5×)
- Active alerts: Force max 1× speed
- Events pending: Auto-pause (overrides speed)

Rationale: Prevent player from missing critical issues at high speed
```

---

## 11.5 Session Structure & Save System

**Typical Play Session:**

**Short Session (15-30 min):**
```
1. Load save (last checkpoint)
2. Review what happened while away (event summary)
3. Check contract progress (any deadlines approaching?)
4. Make 1-2 decisions (hire worker, adjust MES, accept contract)
5. Fast-forward production (2-5× speed)
6. Collect rewards (completed milestones)
7. Save and exit

Player Progress: 1-2 game days, incremental improvement
```

**Medium Session (1-2 hours):**
```
1. Load save
2. Review analytics (last session performance)
3. Plan major change (new production line, R&D project)
4. Implement change (buy machines, train workers, write MES)
5. Test change (simulate or trial run)
6. Monitor results (optimize parameters)
7. Complete 2-3 contracts
8. Save and exit

Player Progress: 5-10 game days, significant milestone
```

**Long Session (3+ hours):**
```
1. Load save
2. Major strategic initiative:
   - Open 2nd factory
   - Complete challenge gauntlet
   - Prestige run (speed-run to L25)
   - Perfect optimization project (90% → 95% OEE)
3. Deep engagement with all systems
4. Experiment with advanced features
5. Save and exit

Player Progress: Weeks to months game time, transformative progress
```

**Save System:**

```
Auto-Save:
- Every 5 minutes (if changes made)
- Before major events (protects against crashes)
- On level up
- On exit (if player forgets to manual save)

Manual Save:
- "Save" button (top menu)
- 3 save slots
- Cloud save (Steam Cloud, optional)

Save Data Includes:
- Factory state (machines, workers, inventory)
- Contracts (active, completed, history)
- Financial data (cash, expenses, revenue)
- Player progress (level, XP, CP, achievements)
- Tech tree (unlocked nodes)
- MES rules (all player-created scripts)
- Analytics history (last 30 days of KPIs)
- Event log (last 100 events)

Save File Size: ~500 KB - 2 MB (compressed JSON)
```

---

## 11.6 Tutorial Integration into Game Flow

**Tutorial Philosophy:** Teach by doing, minimal interruption

**Tutorial Delivery Methods:**

### 11.6.1 Contextual Tooltips (Always Available)

```
First-time hover on any UI element:
  - Show extended tooltip (3-4 sentences)
  - Highlight related elements (arrows, glow)
  - "Learn More" button → opens help panel
  - "Got it" button → dismisses, marks as seen

Example (first hover on MES panel):
┌──────────────────────────────────────────┐
│ 💡 MES (Manufacturing Execution System) │
├──────────────────────────────────────────┤
│ MES automates your factory, adjusting    │
│ machine parameters and routing parts     │
│ based on rules you create.               │
│                                          │
│ Start simple with presets, then learn    │
│ the Block Editor for custom automation.  │
│                                          │
│ [Learn More] [Got it, don't show again]  │
└──────────────────────────────────────────┘
```

---

### 11.6.2 Guided Missions (First 10 Levels)

```
Mission Structure:
- Objective clearly stated
- Hints provided (toggle on/off)
- UI elements highlighted (pulsing glow)
- Success feedback (confetti, sound)
- Reward immediate (XP, cash, unlock)

Example Mission (Level 3):
┌────────────────────────────────────────────┐
│ 📋 MISSION: "First Quality Improvement"   │
├────────────────────────────────────────────┤
│ Your scrap rate is high (6%). Let's fix it│
│                                            │
│ OBJECTIVE:                                 │
│ Reduce scrap rate below 3%                 │
│                                            │
│ HINT 1: Check which machine has most scrap│
│ → Click "View Analytics" in QC panel      │
│                                            │
│ HINT 2: Adjust machine parameters         │
│ → Click machine → "Adjust Parameters"     │
│ → Try reducing feed rate 10%              │
│                                            │
│ REWARD: +500 XP, "Quality Focused" badge  │
│                                            │
│ [View Hint 3] [Skip Mission]              │
└────────────────────────────────────────────┘
```

---

### 11.6.3 Interactive Help System

```
Help Menu (F1 or ? icon):
- Searchable help topics (300+ entries)
- Video tutorials (short 30-60 sec clips)
- "Show me" feature (highlights UI, simulates action)
- Community links (forums, Discord, wiki)

Help Topics Organized:
1. Getting Started (basics, first contract)
2. Machines (each machine type detailed)
3. Workers (hiring, training, management)
4. MES System (presets → blocks → scripting)
5. Contracts & R&D
6. Challenges & Events
7. Advanced Optimization
8. Troubleshooting (common problems)
```

---

## 11.7 Feedback Loops & "Juice"

**Visual Feedback:**

```
Positive Events:
✓ Contract Complete:
  - Green checkmark animation
  - Confetti particle burst (500 particles, 2 sec)
  - Sound: Success chime (pleasant, uplifting)
  - Cash counter animates (+$50,000 scrolling)
  - Achievement popup (if triggered)

✓ Level Up:
  - Screen flash (white, 300ms fade)
  - "LEVEL UP" text zooms in
  - Sound: Triumphant fanfare
  - Tech tree pulses (new nodes available)
  - Player character avatar gets cosmetic upgrade

✓ Perfect Quality (0 scrap batch):
  - Golden sparkle effect on QC station
  - Sound: Magical chime
  - Bonus XP popup (+50 XP)

Negative Events:
✗ Machine Breakdown:
  - Machine sprite turns red, pulsing
  - Smoke particle effect
  - Sound: Error buzz + mechanical grinding
  - Alert icon appears above machine
  - Vibration (if gamepad connected)

✗ Contract Failed:
  - Red "X" animation
  - Screen shake (5px, 200ms)
  - Sound: Sad trombone / failure buzz
  - Reputation bar drops visibly
  - Financial penalty shows (-$5,000 in red)

✗ QC Failure:
  - Part sprite changes to red tint
  - Rejection sound (soft buzz)
  - Scrap counter increments (+1)
  - Cost impact shown (-$200)
```

**Audio Feedback:**

```
Machine Sounds (Looping):
- CNC: High-pitched whir (varies with spindle speed)
  Volume: 60%, 3D positioned (pans left/right based on camera)
- Conveyor: Low rumble
  Volume: 30%, frequency varies with speed
- Assembly: Periodic impacts (wrench tightening)
  Volume: 50%, plays per action

UI Sounds (One-Shot):
- Button click: Soft mechanical "clk"
- Success: Pleasant chime (C major chord)
- Warning: Gentle beep (not alarming)
- Error: Short buzz (500Hz, 200ms)
- Notification: Subtle pop (like message received)

Ambient:
- Factory background: Industrial hum (brown noise filtered)
  Volume: 20%, always playing
- Worker footsteps: Occasional (when worker moves)
  Volume: 40%, 3D positioned

Music: See Section 15 (Audio Design) for full details
```

**Haptic Feedback (Gamepad):**

```
Events that trigger rumble:
- Machine breakdown: Strong pulse (300ms)
- Contract complete: Double tap (100ms, pause 50ms, 100ms)
- Level up: Escalating rumble (weak → strong over 500ms)
- Critical alert: Repeating pulse (every 2 sec until dismissed)
```

---

## 11.8 Pacing & Flow State Maintenance

**Designing for Flow:**

```
Flow State Conditions:
1. Clear goals (contracts provide objectives)
2. Immediate feedback (visual, audio, numeric)
3. Challenge matches skill (difficulty scales with level)
4. Sense of control (player decides everything)
5. Deep focus (minimize interruptions)

Anti-Flow Patterns to Avoid:
✗ Mandatory waiting (no "build time" for machines)
✗ Unclear objectives (always show next milestone)
✗ Overwhelming complexity early (progressive unlocks)
✗ Punishing RNG (events are manageable, not devastating)
✗ Tedious repetition (MES automates boring tasks)
```

**Session Pacing:**

```
Ideal Session Arc (1 hour):
00:00 - Load game, review state (calm)
05:00 - Make plan, set goals (engagement rising)
10:00 - Execute plan (active, focused)
20:00 - First milestone hit (dopamine spike)
25:00 - Problem occurs (tension rises)
30:00 - Solve problem (satisfaction)
35:00 - Optimize, refine (flow state achieved)
50:00 - Major goal achieved (climax)
55:00 - Review results, set next goal (cool down)
60:00 - Natural stopping point, save & exit

Pacing Tools:
- Varied challenge types (prevents monotony)
- Escalating complexity (sustained engagement)
- Frequent small wins (dopamine maintenance)
- Occasional large wins (milestone satisfaction)
- Player-controlled speed (pause = stress relief)
```

---

**End of Section 11 - Complete Game Flow & Event System**

---

# 12. SYSTEM INTEGRATION SUMMARY

## 12.1 Cross-System Dependency Map

**All Systems Interconnected:**

```
                    ┌──────────────┐
                    │   PLAYER     │
                    │  (Level/XP)  │
                    └──────┬───────┘
                           │
        ┌──────────────────┼──────────────────┐
        │                  │                  │
   ┌────▼─────┐      ┌────▼─────┐      ┌────▼─────┐
   │CONTRACTS │      │   TECH   │      │ ECONOMY  │
   │          │◄─────┤   TREE   ├─────►│          │
   └────┬─────┘      └────┬─────┘      └────┬─────┘
        │                 │                  │
        │            ┌────▼─────┐            │
        │            │   MES    │            │
        │            │  SYSTEM  │            │
        │            └────┬─────┘            │
        │                 │                  │
   ┌────▼─────┐      ┌────▼─────┐      ┌────▼─────┐
   │   PLM    │◄────►│PRODUCTION│◄────►│ WORKERS  │
   │  (BOM)   │      │  FLOOR   │      │          │
   └──────────┘      └────┬─────┘      └──────────┘
                          │
                     ┌────▼─────┐
                     │ QUALITY  │
                     │   (QC)   │
                     └──────────┘
```

---

## 12.2 System Integration Details

### 12.2.1 MES ↔ Production Floor

**Data Flow:**
```
MES → Production:
- NC program selection
- Machine parameters (speed, torque, feed)
- Part routing commands
- QC sampling rates

Production → MES:
- Real-time telemetry (progress, sensor data)
- Part completion status
- Quality measurements
- Machine health metrics
```

### 12.2.2 PLM ↔ MES

**Integration Points:**
```
PLM provides:
- BOM (Bill of Materials)
- Process routing (operation sequences)
- Quality specifications
- Torque profiles

MES uses PLM data to:
- Auto-configure machines per part version
- Apply correct quality thresholds
- Route parts to appropriate stations
- Handle ECOs (Engineering Change Orders)
```

### 12.2.3 Contracts ↔ Production

**Workflow:**
```
Contract → Production Planning:
1. Contract specifies: Product, Quantity, Deadline, Quality
2. Planning creates work orders
3. Scheduler allocates to production lines
4. MES executes production
5. QC validates quality
6. Delivery triggers payment
7. Performance affects reputation
```

### 12.2.4 Economy ↔ All Systems

**Financial Impact Map:**
```
Revenue Sources:
- Contracts: $400/unit base
- Quality bonus: +5-10%
- On-time bonus: +10%
- Challenge rewards: CP → Cash

Cost Centers:
- Workers: $2,500-$7,000/mo salary
- Machines: $400-$1,200 maintenance/1000 cycles
- Materials: $145/unit
- Scrap: $200/defect
- R&D: $10k-$100k/project
- Overhead: $5,000/mo base

Net Result: Profitability depends on efficiency
```

---

## 12.3 Key Integration Examples

### Example 1: Contract Fulfillment Chain

```
1. Player accepts contract: 200 engines v2, 7 days
2. Economy: Checks cash available for materials
3. PLM: Retrieves v2 BOM and routing
4. Planning: Schedules 200 work orders
5. MES: Configures machines for v2 specs
6. Workers: Assigned to production line
7. Production: Parts flow through stations
8. QC: Validates each part (145 pass, 3 fail)
9. MES: Adjusts parameters after QC failures
10. Contracts: 145/200 complete, tracking deadline
11. Economy: Materials depleted, costs tracked
12. Player: Monitors progress, makes adjustments
13. Delivery: 200/200 achieved, payment received
14. XP/Reputation: Updated based on quality/timing
```

### Example 2: ECO (Engineering Change) Cascade

```
1. PLM: ECO issued (v2 → v2.1, torque 85 → 95 Nm)
2. PLM: Notifies MES of spec change
3. MES: Updates automation rules
4. Workers: Training notification triggered
5. Production: Flags in-progress parts as "old spec"
6. QC: Different thresholds for v2 vs v2.1
7. Contracts: Tracks both variants separately
8. Economy: Training cost deducted ($1,500)
9. Player: Reviews changes, approves transition
10. Result: Seamless multi-version handling
```

---

## 12.4 Balance & Tuning Philosophy

**Design Goals:**

1. **No Dominant Strategy:** Multiple paths to success
2. **Meaningful Choices:** Trade-offs matter (quality vs speed vs cost)
3. **Recoverable Failures:** Setbacks slow progress, don't end game
4. **Skill Rewarded:** Expert play achieves 120-130% efficiency vs casual 80-90%
5. **Optional Depth:** Can ignore advanced features and still succeed

**Tuning Levers:**

```
If players struggle:
- Reduce contract difficulty (looser deadlines)
- Increase starting cash
- Reduce machine costs
- Lower scrap rates

If too easy:
- Tighten contract deadlines
- Increase random event frequency
- Raise quality requirements
- Introduce competitor AI pressure

Target: 75% of players reach Level 15+
        20% reach Level 25
        5% attempt Prestige mode
```

---

## 12.5 Emergent Gameplay Examples

**Strategy 1: "The Specialist"**
```
Focus: Single product excellence
Approach: Master one engine variant (v2 only)
Result: 0.5% scrap rate, premium contracts
Trade-off: Limited customer base
Viability: High (niche market domination)
```

**Strategy 2: "The Volume King"**
```
Focus: Maximum throughput
Approach: Many lines, basic automation, accept scrap
Result: 3-4% scrap but highest revenue
Trade-off: Lower margins
Viability: High (economy of scale)
```

**Strategy 3: "The R&D Mogul"**
```
Focus: Proprietary products
Approach: Heavy R&D investment, own IP
Result: Highest long-term margins
Trade-off: Slow early growth
Viability: High (endgame strategy)
```

---

## 12.6 Testing Integration Points

**Critical Test Scenarios:**

✅ **New Player Flow:**
- Start game → Tutorial → First contract → Level up → Buy machine
- All systems activate in correct sequence
- No confusion or blockers

✅ **Multi-Contract Juggling:**
- 3 simultaneous contracts, different products
- MES handles variant switching
- Planning balances workload
- All contracts deliverable on time

✅ **ECO Mid-Production:**
- Change spec while 100 parts in progress
- System tracks old vs new versions
- No part mix-ups
- QC applies correct standards

✅ **Financial Crisis:**
- Cash drops below $10k
- Alert triggers
- Player can recover (take loan, sell assets, smaller contracts)
- No bankruptcy forced

✅ **Late-Game Complexity:**
- Level 25, 5 factories, 20 contracts, all techs
- System remains responsive
- UI doesn't overwhelm
- Player can still optimize meaningfully

---

## 12.7 Success Metrics

**Game is Well-Integrated If:**

```
Player Feedback Themes:
✓ "Everything connects logically"
✓ "My decisions matter across multiple systems"
✓ "I discovered a strategy you didn't teach me"
✓ "It feels like running a real factory"
✓ "Complex but not overwhelming"

Telemetry Indicators:
✓ 70%+ players use MES automation
✓ 80%+ engage with R&D system
✓ 60%+ try multiple strategic paths
✓ <5% quit due to confusion
✓ Average session 60-90 minutes
✓ 85%+ positive reviews mention "depth"

Developer Validation:
✓ No single system can be removed without breaking game
✓ Each system affects at least 3 others
✓ Changes to one system ripple logically
✓ Players create unexpected strategies (emergent gameplay)
✓ Balance holds across skill levels
```

---

**End of Section 12 - System Integration Summary**

**END OF PART A: CORE GAME DESIGN (Sections 1-12)**

---

# PART B: TECHNICAL SPECIFICATIONS

---

# 13. TECHNICAL ARCHITECTURE & IMPLEMENTATION

## 13.1 Technology Stack

**Game Engine:** Unity 2022.3 LTS (Long Term Support)
- Mature, stable, excellent 2D support
- C# scripting (familiar to most developers)
- Asset Store for rapid prototyping
- Strong community support

**Programming Language:** C# (.NET Standard 2.1)

**Data Format:** JSON (save files, configuration, modding)

**Version Control:** Git (GitHub/GitLab)

**Build Targets:**
- Primary: Windows (Steam)
- Secondary: macOS, Linux (post-launch)
- Future: Mobile (iOS/Android) - requires UI redesign

---

## 13.2 Architecture Pattern: MVC + ECS Hybrid

**Model-View-Controller (MVC):**
```
MODEL (Data):
- Machine data (status, parameters, telemetry)
- Worker data (skill, fatigue, assignments)
- Contract data (progress, deadlines)
- Player data (level, XP, cash)

VIEW (Presentation):
- Unity UI Canvas (dashboards, panels)
- Sprite renderers (machines, workers, parts)
- Particle systems (effects, feedback)

CONTROLLER (Logic):
- MachineController (executes production)
- MESController (applies automation rules)
- ContractController (tracks progress)
- PlayerController (handles input)
```

**Entity-Component-System (ECS) for Performance:**
```
Use for: Large numbers of parts flowing through factory
- PartEntity: ID, position, status
- PartComponent: Version, quality data
- FlowSystem: Moves parts along conveyors

Why: Efficient for 100+ parts in transit simultaneously
```

---

## 13.3 Core Systems Architecture

### 13.3.1 Production System

```csharp
// Simplified production flow
public class ProductionSystem : MonoBehaviour
{
    private MESController mes;
    private PLMDatabase plm;
    private QualityController qc;
    
    public void ProcessPart(Part part, Machine machine)
    {
        // 1. Retrieve specs from PLM
        var specs = plm.GetSpecs(part.ProductID, part.Version);
        
        // 2. Apply MES rules
        var recipe = mes.GetRecipe(part, machine);
        machine.ApplyParameters(recipe);
        
        // 3. Execute production cycle
        machine.StartCycle(part, OnCycleComplete);
    }
    
    private void OnCycleComplete(Part part, Machine machine)
    {
        // 4. Log telemetry
        DataLogger.Log(machine.GetTelemetry());
        
        // 5. Quality check
        var qcResult = qc.Inspect(part);
        
        if (qcResult.Pass)
        {
            // 6. Route to next station
            ConveyorSystem.Route(part, GetNextStation(part));
        }
        else
        {
            // Scrap part, update metrics
            ScrapHandler.Scrap(part);
            Economy.DeductCost(part.ScrapCost);
        }
    }
}
```

---

### 13.3.2 MES System Architecture

```csharp
// MES Rule Engine
public class MESController : MonoBehaviour
{
    private List<MESRule> activeRules;
    
    public MachineRecipe GetRecipe(Part part, Machine machine)
    {
        var recipe = GetBaseRecipe(part.ProductID);
        
        // Apply active MES rules
        foreach (var rule in activeRules)
        {
            if (rule.MatchesCondition(part, machine))
            {
                recipe = rule.ModifyRecipe(recipe);
            }
        }
        
        return recipe;
    }
}

// MES Rule (player-created)
[Serializable]
public class MESRule
{
    public string Name;
    public MESCondition Condition;  // IF part.version == 2
    public MESAction Action;        // THEN torque = 95
    public bool Active;
    
    public bool MatchesCondition(Part part, Machine machine)
    {
        return Condition.Evaluate(part, machine);
    }
    
    public MachineRecipe ModifyRecipe(MachineRecipe recipe)
    {
        return Action.Apply(recipe);
    }
}
```

---

### 13.3.3 Data Model (ScriptableObjects)

```csharp
// Product Definition (PLM)
[CreateAssetMenu(fileName = "Product", menuName = "Game/Product")]
public class ProductSO : ScriptableObject
{
    public string ProductID;
    public string DisplayName;
    public int Version;
    public BillOfMaterials BOM;
    public ProcessRouting Routing;
    public QualitySpec QualitySpec;
}

// Machine Definition
[CreateAssetMenu(fileName = "Machine", menuName = "Game/Machine")]
public class MachineSO : ScriptableObject
{
    public string MachineID;
    public MachineType Type;  // CNC, Lathe, Assembly, etc
    public int BaseCycleTime;  // seconds
    public float BaseScrapRate;  // 0.0 - 1.0
    public int PurchaseCost;
    public int MaintenanceCost;
    public Sprite Icon;
}

// Contract Definition
[CreateAssetMenu(fileName = "Contract", menuName = "Game/Contract")]
public class ContractSO : ScriptableObject
{
    public string ContractID;
    public ProductSO Product;
    public int Quantity;
    public int DeadlineDays;
    public float MaxScrapRate;  // e.g., 0.02 = 2%
    public int BasePayment;
    public int BonusOnTime;
    public int BonusQuality;
}
```

---

## 13.4 Save/Load System

**Save Data Structure:**

```json
{
  "version": "1.0.0",
  "timestamp": "2025-12-21T15:30:00Z",
  "player": {
    "level": 12,
    "xp": 30245,
    "cash": 142500,
    "challengePoints": 8450,
    "reputation": 78
  },
  "factory": {
    "machines": [
      {
        "id": "CNC_02",
        "type": "CNC_Mill",
        "position": {"x": 5, "y": 10},
        "status": "Running",
        "toolWear": 0.66,
        "assignedWorker": "Worker_Sarah",
        "currentPart": "ENG-v2-S00542"
      }
    ],
    "workers": [
      {
        "id": "Worker_Sarah",
        "skill": 95,
        "specialty": "Machining",
        "fatigue": 35,
        "assignedMachine": "CNC_02"
      }
    ]
  },
  "contracts": [
    {
      "id": "CNT-2025-042",
      "product": "Engine_v2",
      "quantity": 200,
      "progress": 145,
      "deadline": "2025-12-28T23:59:59Z",
      "status": "Active"
    }
  ],
  "mesRules": [
    {
      "id": "RULE_MultiVariant_01",
      "type": "BlockLogic",
      "active": true,
      "logic": "IF part.version==2 THEN torque=95 ELSE torque=85"
    }
  ],
  "techTree": {
    "unlockedTiers": [0, 1, 2],
    "unlockedNodes": ["MES_GUI", "MES_Blocks", "R&D_Dept", "MultiLine"]
  }
}
```

**Save System Implementation:**

```csharp
public class SaveSystem : MonoBehaviour
{
    private const string SAVE_KEY = "SaveSlot_";
    
    public void SaveGame(int slot)
    {
        var saveData = new SaveData
        {
            version = Application.version,
            timestamp = DateTime.UtcNow,
            player = GameManager.Instance.Player.ToSaveData(),
            factory = FactoryManager.Instance.ToSaveData(),
            contracts = ContractManager.Instance.ToSaveData(),
            mesRules = MESController.Instance.ToSaveData(),
            techTree = TechTreeManager.Instance.ToSaveData()
        };
        
        string json = JsonUtility.ToJson(saveData, true);
        string encrypted = Encrypt(json);  // Simple encryption
        
        PlayerPrefs.SetString(SAVE_KEY + slot, encrypted);
        PlayerPrefs.Save();
        
        Debug.Log($"Game saved to slot {slot}");
    }
    
    public bool LoadGame(int slot)
    {
        string key = SAVE_KEY + slot;
        if (!PlayerPrefs.HasKey(key)) return false;
        
        string encrypted = PlayerPrefs.GetString(key);
        string json = Decrypt(encrypted);
        
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        
        // Restore game state
        GameManager.Instance.Player.LoadFromSaveData(saveData.player);
        FactoryManager.Instance.LoadFromSaveData(saveData.factory);
        ContractManager.Instance.LoadFromSaveData(saveData.contracts);
        MESController.Instance.LoadFromSaveData(saveData.mesRules);
        TechTreeManager.Instance.LoadFromSaveData(saveData.techTree);
        
        Debug.Log($"Game loaded from slot {slot}");
        return true;
    }
}
```

---

## 13.5 Performance Optimization

**Target Performance:**
- 60 FPS on mid-range hardware (GTX 1060 / Ryzen 5 equivalent)
- <2 GB RAM usage
- <500 MB disk space

**Optimization Strategies:**

### 13.5.1 Object Pooling

```csharp
// Pool for parts (avoid instantiate/destroy spam)
public class PartPool : MonoBehaviour
{
    private Queue<GameObject> pool = new Queue<GameObject>();
    public GameObject partPrefab;
    
    public GameObject GetPart()
    {
        if (pool.Count > 0)
        {
            var part = pool.Dequeue();
            part.SetActive(true);
            return part;
        }
        else
        {
            return Instantiate(partPrefab);
        }
    }
    
    public void ReturnPart(GameObject part)
    {
        part.SetActive(false);
        pool.Enqueue(part);
    }
}
```

### 13.5.2 Update Optimization

```csharp
// Don't update every machine every frame
public class MachineManager : MonoBehaviour
{
    private List<Machine> machines;
    private int updateIndex = 0;
    private const int MACHINES_PER_FRAME = 5;
    
    void Update()
    {
        // Stagger updates
        for (int i = 0; i < MACHINES_PER_FRAME; i++)
        {
            machines[updateIndex].UpdateMachine();
            updateIndex = (updateIndex + 1) % machines.Count;
        }
    }
}
```

### 13.5.3 LOD (Level of Detail)

```csharp
// Reduce detail for distant objects
public class MachineLOD : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem particles;
    
    void Update()
    {
        float distToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        
        if (distToCamera > 20f)
        {
            // Far: disable animations, particles
            animator.enabled = false;
            particles.Stop();
        }
        else
        {
            // Close: full detail
            animator.enabled = true;
            particles.Play();
        }
    }
}
```

---

## 13.6 Modding Support (Future)

**Modding API Exposure:**

```csharp
// Allow modders to add custom machines
public interface IModdableMachine
{
    string MachineID { get; }
    string DisplayName { get; }
    MachineType Type { get; }
    
    void ProcessPart(Part part);
    MachineRecipe GetDefaultRecipe();
}

// Mod loader
public class ModLoader : MonoBehaviour
{
    public void LoadMods()
    {
        string modPath = Application.dataPath + "/Mods/";
        var modDLLs = Directory.GetFiles(modPath, "*.dll");
        
        foreach (var dll in modDLLs)
        {
            Assembly assembly = Assembly.LoadFrom(dll);
            var machineTypes = assembly.GetTypes()
                .Where(t => typeof(IModdableMachine).IsAssignableFrom(t));
            
            foreach (var type in machineTypes)
            {
                IModdableMachine machine = (IModdableMachine)Activator.CreateInstance(type);
                RegisterMachine(machine);
            }
        }
    }
}
```

---

**End of Section 13 - Technical Architecture**

---

# 14. ECONOMY BALANCE & TUNING PARAMETERS

## 14.1 Starting Conditions

**New Game Defaults:**
```
Cash: $50,000
Machines: CNC_01, Lathe_01 (pre-placed)
Workers: 2 (Skill 60 generalists)
Tech: Tier 0 only
Contracts: 1 tutorial contract (50 engines, 3 days)
```

---

## 14.2 Machine Economics

| Machine Type | Purchase Cost | Maintenance/1000 Cycles | Scrap Rate (Base) | Cycle Time (Base) |
|--------------|---------------|-------------------------|-------------------|-------------------|
| CNC Mill | $35,000 | $800 | 4% | 12 min |
| CNC Lathe | $28,000 | $600 | 5% | 10 min |
| Assembly Station | $12,000 | $200 | 8% (worker-dependent) | 8 min |
| Atlas Nutrunner | $18,000 | $400 | 2% | 3 min |
| QC Station | $22,000 | $300 | N/A | 5 min (inspection) |
| AGV (Tier 4) | $45,000 | $1,200 | N/A | N/A |

**ROI Calculation Example:**
```
CNC Mill Purchase: $35,000
Produces: 5 parts/hour (12 min/part)
Revenue per part: $400 (average contract)
Cost per part: $145 (material) + $15 (labor) = $160
Profit per part: $240

Break-even: $35,000 ÷ $240 = 146 parts = 29 hours production
Payback period: ~1 week game time (if running 24/7)
```

---

## 14.3 Worker Economics

**Salary Structure:**

| Skill Level | Monthly Salary | Efficiency Multiplier | Specialty Bonus |
|-------------|----------------|----------------------|-----------------|
| 50-60 (Entry) | $2,500 | 0.85× | - |
| 61-75 (Competent) | $3,500 | 1.0× | +15% |
| 76-90 (Skilled) | $5,000 | 1.15× | +20% |
| 91-100 (Expert) | $7,000 | 1.30× | +25% |

**Training Costs:**

| Training Type | Duration | Cost | Benefit |
|---------------|----------|------|---------|
| Basic Machining | 1 week | $1,500 | +10 skill, Machining specialty |
| Assembly Specialist | 1 week | $1,500 | +10 skill, Assembly specialty |
| QC Certification | 1 week | $1,500 | +10 skill, QC specialty |
| MES Coding | 2 weeks | $3,000 | Can create/edit MES rules |
| Atlas Certification | 1 week | $2,000 | Can operate Nutrunners |

**Worker Value Analysis:**
```
Entry Worker ($2,500/mo):
- Produces 5 parts/hour (base efficiency)
- Monthly output: ~850 parts (170 hours)
- Revenue: 850 × $240 profit = $204,000
- Net value: $204,000 - $2,500 = $201,500/mo

Expert Worker ($7,000/mo):
- Produces 6.5 parts/hour (1.3× efficiency)
- Monthly output: ~1,105 parts
- Revenue: 1,105 × $240 = $265,200
- Net value: $265,200 - $7,000 = $258,200/mo

Conclusion: Expert worth +$56,700/mo despite higher salary
```

---

## 14.4 Contract Economics

**Contract Types & Profitability:**

| Contract Type | Base Payment/Unit | Volume | Margin | Risk |
|---------------|-------------------|---------|--------|------|
| OEM (Standard) | $400 | High (200-500) | 60% | Low |
| Premium (Aerospace) | $650 | Low (50-100) | 75% | Medium (strict QC) |
| Co-Development | $500 | Medium (100-200) | 70% | Medium (R&D cost) |
| In-House Product | $550 | Medium | 80% | High (upfront R&D) |

**Bonus Structure:**
```
Base Payment: $400/unit
+ On-Time Bonus: +10% ($40/unit)
+ Quality Bonus (<1.5% scrap): +5% ($20/unit)
+ Perfect Delivery (0 defects, early): +15% ($60/unit)

Maximum: $520/unit (30% bonus)
Penalty: -$100/unit per day late
```

**Example Contract Analysis:**
```
Contract: OEM Standard, 200 engines, 7 days

Revenue (Perfect):
- Base: 200 × $400 = $80,000
- On-time: +$8,000
- Quality: +$4,000
- Total: $92,000

Costs:
- Materials: 200 × $145 = $29,000
- Labor: 7 days × 5 workers × $16/hr × 24hr = $13,440
- Machine maintenance: ~$1,200
- Overhead: $1,200 (7 days)
- Total: $44,840

Profit: $92,000 - $44,840 = $47,160 (106% ROI)
Profit Margin: 51.3%
```

---

## 14.5 Material Costs

| Material | Cost/Unit | Used For |
|----------|-----------|----------|
| Aluminum 6061 Billet | $145 | Engine blocks |
| Forged Steel | $180 | Crankshafts |
| Grade 8 Bolts (M12) | $2 each | Assembly (20 per engine) |
| Coolant/Cutting Fluid | $5/batch | Machining overhead |

**Total Material Cost per Engine:** ~$165-$185 (depending on variant)

---

## 14.6 Overhead Costs

**Monthly Fixed Costs:**
```
Facility Rent: $2,000/mo
Utilities (power, water): $1,500/mo
Insurance: $800/mo
Software licenses (MES, PLM): $700/mo
Total: $5,000/mo baseline

Scales with factory size:
- 1-5 machines: $5,000/mo
- 6-15 machines: $8,000/mo
- 16-30 machines: $12,000/mo
- 31+ machines: $18,000/mo
```

---

## 14.7 XP & Progression Economy

**XP Sources:**

| Action | XP Reward | Frequency |
|--------|-----------|-----------|
| Produce 1 unit | +5 XP | Per part |
| Complete contract (on-time) | +500 XP | Per contract |
| Perfect delivery | +1,200 XP | Per contract |
| Complete challenge (Bronze) | +300 XP | Per challenge |
| Complete challenge (Gold) | +1,500 XP | Per challenge |
| Train worker | +100 XP | Per training |
| Unlock tech | +200 XP | Per unlock |
| Achieve 90% OEE | +500 XP | One-time milestone |

**XP Curve (Cumulative):**
```
Level 1 → 2: 1,000 XP (0.5 hours)
Level 5 → 6: 6,000 XP (3 hours)
Level 10 → 11: 20,000 XP (10 hours)
Level 15 → 16: 60,000 XP (25 hours)
Level 20 → 21: 130,000 XP (55 hours)
Level 25 (Max): 300,000 XP (100+ hours)
```

**Challenge Points (CP) Economy:**

| CP Source | CP Reward |
|-----------|-----------|
| Challenge (Bronze) | +500 CP |
| Challenge (Silver) | +1,500 CP |
| Challenge (Gold) | +5,000 CP |
| Daily Challenge | +500-2,000 CP |
| Achievement | +100-1,000 CP |

**CP Shop (Example Prices):**
```
Exclusive Machines:
- Quantum CNC: 50,000 CP
- Auto-Nutrunner: 30,000 CP

MES Templates:
- Mixed-Model Master: 5,000 CP
- Predictive Perfection: 8,000 CP

Cosmetics:
- UI Themes: 2,000 CP
- Factory Skins: 3,000 CP
```

---

## 14.8 Difficulty Scaling

**By Player Level:**

| Level Range | Contract Difficulty | Average Deadline | Quality Requirement |
|-------------|---------------------|------------------|---------------------|
| 1-5 | Easy | 7-10 days | <5% scrap |
| 6-10 | Moderate | 5-7 days | <3% scrap |
| 11-15 | Hard | 3-5 days | <2% scrap |
| 16-20 | Very Hard | 2-4 days | <1.5% scrap |
| 21-25 | Expert | 1-3 days | <1% scrap |

**Event Frequency:**

| Level Range | Breakdowns/Month | Material Delays | Rush Orders |
|-------------|------------------|-----------------|-------------|
| 1-5 | 0-1 | Rare | 1 per month |
| 6-10 | 1-2 | Occasional | 2 per month |
| 11-15 | 2-3 | Regular | 3 per month |
| 16-20 | 3-4 | Frequent | 4 per month |
| 21-25 | 4-5 | Very frequent | 5+ per month |

---

## 14.9 Balance Validation Formulas

**Profitability Check:**
```
MonthlyRevenue = ContractsCompleted × AverageRevenue
MonthlyCosts = Workers × Salary + Machines × Maintenance + Overhead
NetProfit = MonthlyRevenue - MonthlyCosts

Target: NetProfit > 0 for competent play
       NetProfit > 20% revenue for good play
       NetProfit > 50% revenue for expert play
```

**Growth Rate:**
```
Level 1-5: Should double net worth every 2-3 levels
Level 6-15: Should double net worth every 4-5 levels
Level 16-25: Should double net worth every 5-8 levels

Prevents: Exponential runaway or stagnation
```

**Time Investment:**
```
Tutorial to productive: <30 minutes
First contract complete: <1 hour
Level 10 reached: 8-12 hours
Level 25 reached: 80-120 hours
Prestige attempt: 150-200 hours

Target: Respect player time, consistent pacing
```

---

## 14.10 Balance Levers (Post-Launch Tuning)

**If Players Struggle:**
```
1. Increase starting cash ($50k → $75k)
2. Reduce machine costs (-20%)
3. Extend contract deadlines (+1-2 days)
4. Reduce base scrap rates (-1%)
5. Increase contract payments (+10%)
```

**If Too Easy:**
```
1. Tighten deadlines (-1 day)
2. Increase event frequency (+20%)
3. Raise quality requirements (-0.5% scrap allowed)
4. Reduce contract bonuses (-5%)
5. Add competitor pressure (AI factories)
```

---

**End of Section 14 - Economy Balance**

---



# 15. AUDIO DESIGN

## 15.1 Sound Effects (SFX)

**Machine Sounds:**
- CNC Machining: High-pitched whir (looping), pitch varies with spindle speed (1500-3000 RPM = 200-400Hz)
- Lathe: Lower mechanical hum (looping, ~150Hz)
- Assembly: Pneumatic hiss + impact wrench clicks (one-shot per bolt)
- Conveyor: Low rumble (looping), pitch ∝ speed
- AGV: Electric motor whine (250Hz), navigation beeps

**UI Sounds:**
- Button Click: Soft mechanical click (50ms)
- Success: Pleasant chime (C major chord, 300ms)
- Warning: Gentle beep (440Hz, 200ms)
- Error: Short buzz (150Hz, 300ms)
- Notification: Subtle pop (like message received)

**Ambient:**
- Factory Background: Subtle industrial ambience (low-pass filtered white noise, 20% volume)
- Worker Movement: Footsteps (occasional, random timing)
- Part Movement: Metallic clinks when parts transfer between stations

**Volume Levels (Default):**
- Machine SFX: 60%
- UI Sounds: 80%
- Ambient: 30%
- Music: 50%

---

## 15.2 Music System

**Adaptive Music Layers:**
```
Layer 1 (Base): Calm electronic/industrial beat (always playing)
Layer 2 (Productivity): Adds when production running smoothly (OEE >75%)
Layer 3 (Tension): Adds when deadlines <24hrs OR bottleneck detected
Layer 4 (Success): Flourish when contracts complete (15 sec overlay)
```

**Music Tracks:**
- Menu/Setup: Ambient, exploratory (2-3 min loop)
- Early Game: Simple, hopeful (teaches learning mood)
- Mid Game: Energetic, productive (factory humming)
- Late Game: Epic, triumphant (empire building)
- Challenge Mode: Tense, focused (high-stakes)

**Adaptive Logic:**
```
IF NoActiveProduction THEN
  MusicLayer = Base only
ELSE IF ProductionSmooth AND NoDeadlines THEN
  MusicLayer = Base + Productivity
ELSE IF DeadlineWithin24Hours OR BottleneckDetected THEN
  MusicLayer = Base + Productivity + Tension
ELSE IF ContractCompleted THEN
  MusicLayer = All + Success (15 sec flourish, then revert)
END
```

---

## 15.3 Implementation Notes

- **Format:** OGG Vorbis (open-source, good compression)
- **Spatial Audio:** 2D panning based on camera position
- **Ducking:** Music volume -20% when important UI notifications play
- **Player Controls:** Master, Music, SFX, Ambient (independent sliders)
- **Accessibility:** Option to disable looping machine sounds (reduce auditory fatigue)

---

# 16. NARRATIVE & FLAVOR ELEMENTS

## 16.1 Player Character Background

**You are:** Alex Rivera, newly appointed Production Engineering Manager

**Backstory:**
- Former assembly line worker promoted to management
- Inherited a struggling factory from retiring owner (tutorial context)
- Goal: Revitalize factory, prove yourself, build legacy

**Personality:** Determined, practical, learns from mistakes

---

## 16.2 Customer Personalities

**Acme Automotive (OEM)**
- Contact: Robert Chen, VP Procurement
- Style: Professional, no-nonsense, data-driven
- Contract messages: "We need 200 units by Friday. Quality is non-negotiable."

**GreenDrive Motors (Startup)**
- Contact: Maya Rodriguez, CEO
- Style: Enthusiastic, flexible, collaborative
- Contract messages: "Excited to co-develop this with you! Let's revolutionize EVs together!"

**Industrial Power Corp (Heavy Equipment)**
- Contact: James Peterson, Operations Director
- Style: Traditional, risk-averse, values reliability
- Contract messages: "Our machines run 24/7. We can't afford failures. Deliver perfection."

---

## 16.3 Event Narratives

**Machine Breakdown Event:**
```
"The spindle bearing on CNC_02 has failed. Maintenance reports unusual vibration 
over the past week - should've caught this earlier with predictive monitoring. 
Your call: Emergency repair ($5k, 8hrs) or use spare parts ($1.2k, 2hrs)?"
```

**Rush Order Event:**
```
"Urgent call from GreenDrive Motors: Their supplier fell through. They need 100 
engines in 3 days - half your normal timeline. They're offering 50% premium. 
Can your factory handle the pressure?"
```

---

## 16.4 Achievement Flavor Text

**"Assembly Line Worker" (Produce 100 engines):**
```
"Every journey begins with a single bolt. You've proven you can produce at scale."
```

**"Zero Defect Master" (0% scrap for 1,000 units):**
```
"Perfection isn't luck - it's discipline, precision, and relentless optimization. 
Your QC team deserves a raise."
```

---

# 17. QA & TESTING STRATEGY

## 17.1 Testing Phases

**Phase 1: Unit Testing (Throughout Development)**
- Test individual systems in isolation
- Automated tests for: Economy calculations, MES rule evaluation, save/load
- Coverage target: 70% code coverage

**Phase 2: Integration Testing (Milestone-Based)**
- Test system interactions (MES ↔ Production, Contracts ↔ Economy)
- Manual test scenarios for each major feature
- Performance profiling (60 FPS on target hardware)

**Phase 3: Playtest Alpha (Internal, Week 20-22)**
- 5-10 internal testers
- Focus: Core loop, balance, progression pacing
- Iterate based on feedback

**Phase 4: Closed Beta (Week 28-30)**
- 50-100 external testers (Steam playtest)
- Focus: Bug hunting, balance validation, UX friction
- Collect telemetry (progression rates, feature adoption)

**Phase 5: Open Beta / Early Access (Week 32+)**
- Public release, ongoing updates
- Focus: Community feedback, long-term balance, content additions

---

## 17.2 Test Scenarios

**Scenario 1: New Player Experience**
```
1. Start new game
2. Complete tutorial without help
3. Deliver first contract successfully
4. Level up to Level 5
5. Buy first additional machine
Success Criteria: <5% dropout rate, <10 min to first contract
```

**Scenario 2: Multi-Contract Stress Test**
```
1. Accept 5 simultaneous contracts
2. All different products (v1, v2, v3)
3. Overlapping deadlines
4. Random event occurs (breakdown)
Success Criteria: All deliverable with competent play, no soft-locks
```

**Scenario 3: Save/Load Integrity**
```
1. Play to Level 15, 3 active contracts, MES rules active
2. Save game mid-production (parts in transit)
3. Exit, restart, load save
Success Criteria: All state preserved, no data loss, resume seamlessly
```

---

## 17.3 Performance Benchmarks

**Target Hardware:** GTX 1060 / Ryzen 5 3600 (mid-range 2020 PC)

| Scenario | Target FPS | RAM Usage | Load Time |
|----------|-----------|-----------|-----------|
| Early game (5 machines) | 60 FPS | <1 GB | <5 sec |
| Mid game (15 machines) | 60 FPS | <1.5 GB | <8 sec |
| Late game (50 machines) | 45 FPS | <2 GB | <15 sec |

---

## 17.4 Bug Severity Classification

| Severity | Definition | Example | Response Time |
|----------|------------|---------|---------------|
| Critical | Game unplayable | Save corruption, crash on launch | <24 hours |
| High | Major feature broken | Contracts don't pay, MES doesn't work | <3 days |
| Medium | Annoyance, workaround exists | UI misalignment, typo | <1 week |
| Low | Cosmetic only | Wrong icon color | Next patch |

---

# 18. ACCESSIBILITY & LOCALIZATION

## 18.1 Accessibility Features

**Colorblind Modes:**
- Protanopia (red-blind): Replace red with blue
- Deuteranopia (green-blind): Replace green with blue
- Tritanopia (blue-blind): Replace blue with red
- Full Colorblind: Patterns + icons only (no color dependency)

**Text Scaling:**
- Small: 100% (12px body text)
- Medium: 125% (15px)
- Large: 150% (18px)
- Extra Large: 200% (24px)

**High Contrast Mode:**
- Black background, white text
- High contrast state colors (no pastels)
- 2px minimum borders

**Screen Reader Support:**
- ARIA labels on all UI elements
- Keyboard navigation fully supported
- Focus indicators (2px yellow outline)
- State changes announced

**Reduce Motion:**
- Toggle OFF: Animations, particles, screen shake
- Toggle ON: Instant transitions, static sprites

---

## 18.2 Localization

**Supported Languages (Launch):**
- English (US/UK)
- Spanish (ES/LATAM)
- French
- German
- Chinese (Simplified)
- Japanese

**Supported Languages (Post-Launch):**
- Portuguese (BR)
- Russian
- Korean
- Italian
- Polish

**Localization Guidelines:**
- All text externalized to JSON files
- No hardcoded strings in code
- UI designed for 30% text expansion (German/French are longer)
- Number formatting: Locale-aware (1,000.50 vs 1.000,50)
- Date/time: Locale-aware
- Currency: $ vs € vs ¥ (cosmetic only, game uses generic "Cash")

**Translation Process:**
- Professional translation for tier-1 languages
- Community translation for tier-2 (with moderation)
- In-game language switcher (no restart required)

---

# 19. MVP DEFINITION & SCOPE

## 19.1 MVP Core Features (Must-Have for Launch)

**Production Systems:**
✅ 6 machine types (CNC, Lathe, Assembly, Nutrunner, QC, Conveyor)
✅ Worker management (hire, train, assign)
✅ Basic material flow (conveyors, buffers)
✅ Real-time production simulation

**MES System:**
✅ Tier 0-2 (Manual, GUI Presets, Block Editor)
✅ Basic automation rules (IF-THEN logic)
✅ Machine parameter control

**Contracts:**
✅ 3 contract types (OEM, Co-Dev, In-House)
✅ 10 unique customers
✅ Deadline/quality tracking
✅ Payment/penalty system

**Progression:**
✅ Levels 1-25
✅ Tech tree (Tiers 0-4)
✅ XP/Challenge Points
✅ Basic achievements

**UI/UX:**
✅ Main game screen (factory view)
✅ All core dashboards (Contracts, MES, KPIs, Alerts)
✅ Tutorial system
✅ Save/load (3 slots)

**Game Modes:**
✅ Campaign (Level 1-25 progression)
✅ Sandbox (unlock at Level 10)

---

## 19.2 Post-MVP Features (Deferred to Updates)

**Phase 1 (Month 1-3 post-launch):**
- MES Tier 3 (text scripting)
- AGVs (Tier 4 unlock)
- Digital Twin simulation
- 5 additional challenges
- QoL improvements (based on feedback)

**Phase 2 (Month 4-6):**
- Multi-factory management
- Global expansion (new regions)
- Prestige system
- Multiplayer alpha (co-op)

**Phase 3 (Month 7-12):**
- New industry (Transmissions)
- AI-assisted optimization (Tier 5)
- Modding support (Steam Workshop)
- Additional languages

---

## 19.3 Cut Features (Nice-to-Have, Not Essential)

- VR mode
- Mobile port
- Competitive multiplayer
- Real-time market simulation
- Employee personalities (morale system simplified)

---

# 20. DEVELOPMENT PHASES & MILESTONES

## 20.1 Development Timeline (30 Weeks)

**Phase 1: Pre-Production (Weeks 1-4)**
- Finalize GDD
- Create technical architecture document
- Set up Unity project, version control
- Prototype core loop (machine → worker → part → contract)
- Milestone: Playable prototype (1 machine, 1 worker, 1 contract)

**Phase 2: Core Systems (Weeks 5-12)**
- Implement all machine types
- Worker system (hire, train, assign, skill)
- Contract system (accept, track, deliver, payment)
- Basic MES (Tier 0-1: Manual + GUI presets)
- Factory UI (top-down view, drag-and-drop machines)
- Milestone: Vertical slice (Levels 1-5 playable)

**Phase 3: Advanced Systems (Weeks 13-20)**
- MES Block Editor (Tier 2)
- PLM system (BOM, routing, ECOs)
- R&D system (projects, co-development)
- Tech tree (Tiers 0-3)
- Planning & scheduling tools
- Milestone: Alpha (Levels 1-15 playable, all core systems)

**Phase 4: Content & Polish (Weeks 21-26)**
- Levels 16-25 content
- 10 challenges
- Event system (breakdowns, rush orders, etc)
- Achievements (50+)
- Audio implementation (SFX, music)
- Tutorial system
- Milestone: Beta (feature-complete, needs polish)

**Phase 5: Testing & Launch Prep (Weeks 27-30)**
- Internal playtesting
- Closed beta (Steam playtest)
- Bug fixing
- Balance tuning
- Localization (6 languages)
- Steam store page, marketing materials
- Milestone: Launch (Early Access or full release)

---

## 20.2 Team Structure

**Core Team (5 people):**
- **Game Designer/Producer:** GDD owner, balance tuning, project management
- **Lead Programmer:** Core systems, MES, save/load, architecture
- **UI/UX Designer:** Interface design, wireframes, user testing
- **2D Artist:** Machines, workers, UI assets, animations
- **Audio Designer:** SFX, music, implementation

**Extended Team (contractors):**
- QA Testers (5-10, part-time during beta)
- Translators (6 languages)
- Marketing/Community Manager (part-time)

---

## 20.3 Risks & Mitigation

| Risk | Probability | Impact | Mitigation |
|------|-------------|--------|------------|
| MES complexity overwhelms players | High | High | Extensive tutorial, progressive unlocks, presets |
| Balance too hard or too easy | Medium | High | Frequent playtesting, telemetry, tuning levers |
| Performance issues (50+ machines) | Medium | Medium | Profiling, optimization, LOD system |
| Scope creep (too many features) | High | Medium | Strict MVP, defer nice-to-haves |
| Save corruption bugs | Low | Critical | Automated tests, versioning, backups |

---

# 21. ASSET PRODUCTION PIPELINE

## 21.1 Art Asset Specifications

**Machines (Sprites):**
- Resolution: 192×192px (3×3 cells @ 64px/cell)
- Style: Flat design, subtle gradients
- States: Idle, Running (animated), Error (red tint), Maintenance (orange tint)
- Format: PNG (transparency), sprite sheet for animations
- Naming: `machine_cnc_idle.png`, `machine_cnc_running_000.png` (frame 0)

**Workers (Sprites):**
- Resolution: 32×32px
- Style: Simple humanoid shape, color-coded by specialty
- States: Idle, Walking (4-frame animation), Working (2-frame)
- Format: PNG sprite sheet
- Naming: `worker_idle.png`, `worker_walk_000.png`

**UI Icons:**
- Resolution: 32×32px
- Style: Simple, high-contrast, recognizable at small size
- Format: PNG
- Naming: `icon_cash.png`, `icon_contract.png`, `icon_xp.png`

**Parts (In-Transit):**
- Resolution: 16×16px
- Color-coded by variant (v1: blue, v2: green, v3: orange)
- Format: PNG
- Naming: `part_v1.png`, `part_v2.png`

---

## 21.2 Audio Asset Specifications

**SFX:**
- Format: WAV (source), OGG Vorbis (game)
- Sample Rate: 44.1kHz
- Bit Depth: 16-bit
- Looping sounds: Seamless loop points marked
- Naming: `sfx_cnc_running_loop.ogg`, `sfx_button_click.ogg`

**Music:**
- Format: OGG Vorbis
- Sample Rate: 44.1kHz
- Bitrate: 192kbps (high quality)
- Length: 2-3 min loops (seamless)
- Layers exported separately (for adaptive music)
- Naming: `music_gameplay_base.ogg`, `music_gameplay_tension.ogg`

---

## 21.3 Naming Conventions

**Files:**
- Lowercase, underscores (no spaces)
- Category prefix: `machine_`, `worker_`, `icon_`, `sfx_`, `music_`
- Descriptive: `machine_cnc_running_anim_strip8.png` (8-frame strip)

**Unity Prefabs:**
- PascalCase: `MachineCNC`, `WorkerPrefab`, `PartV2Prefab`

**Scripts:**
- PascalCase: `MachineController.cs`, `MESRuleEngine.cs`

---

# 22. LAUNCH STRATEGY & POST-LAUNCH ROADMAP

## 22.1 Launch Platform

**Primary:** Steam (PC)
- Early Access or Full Release (TBD based on polish level)
- Price: $19.99 (Early Access), $24.99 (Full Release)
- Discount strategy: 10% launch week, 20% during Steam sales

**Secondary (Post-Launch):**
- GOG.com (DRM-free version)
- Epic Games Store (if exclusive deal offered)
- Itch.io (for indie audience)

---

## 22.2 Marketing Strategy

**Pre-Launch (3 months before):**
- Steam store page live (wishlists)
- Devlog series (blog + YouTube)
- Reddit posts (r/gamedev, r/tycoon, r/IndieDev)
- Discord server (community building)
- Press kit sent to gaming journalists

**Launch Week:**
- Launch trailer (YouTube, Twitter, Steam)
- Press release to gaming sites (PC Gamer, RPS, etc)
- Streamer outreach (send keys to 20-30 streamers)
- Reddit AMA (r/Games, r/tycoon)
- Social media push (Twitter, Facebook, TikTok)

**Post-Launch:**
- Weekly devlogs (what's being worked on)
- Community challenges (monthly)
- Content updates every 2-3 months
- Steam sale participation

---

## 22.3 Early Access Roadmap (if applicable)

**Month 1-3:**
- QoL updates (based on feedback)
- Balance tuning (economy, progression)
- Bug fixes (priority: critical/high)
- Feature: MES Tier 3 (text scripting)

**Month 4-6:**
- Feature: AGVs (Tier 4)
- Feature: Digital Twin simulation
- Content: 10 new challenges
- Content: 5 new achievements

**Month 7-9:**
- Feature: Multi-factory management
- Feature: Prestige system
- Content: New contract types
- Polish: Improved tutorial

**Month 10-12:**
- Feature: Multiplayer alpha (co-op)
- Feature: Modding support (Steam Workshop)
- Content: New industry (Transmissions)
- Full Release preparation

---

## 22.4 Success Metrics

**Launch Targets:**
- 10,000 wishlists (pre-launch)
- 2,000 units sold (week 1)
- 85%+ positive reviews (Steam)
- <5% refund rate

**Engagement Targets:**
- Average playtime: 20 hours (first month)
- 30% D1 retention, 15% D7, 5% D30
- 40% of players reach Level 15+
- 10% of players reach Level 25

**Financial Targets:**
- Break-even: 5,000 units sold ($100k revenue = covers dev cost)
- Profitability: 10,000 units ($200k revenue)
- Success: 50,000 units ($1M revenue)

---

**END OF GDD - ENGINE ASSEMBLY TYCOON**

**Total Sections: 22/22 ✅ COMPLETE**

**Document Statistics:**
- Total Lines: ~13,000+
- Total Pages: ~350 (estimated)
- Sections: 22
- Comprehensiveness: Production-ready

---

**Document Version:** 1.0.0  
**Last Updated:** December 21, 2025  
**Author:** Joakim (Solo Developer)  
**Status:** COMPLETE - Ready for Development
