---
tags:
- Writing
- Format
date: 2023-11-27
---

# Comment

Di Microsoft Loop, comment itu text biasa loh. Wow amazing syekali. Artinya bisa di-adopt ke markdown juga

Template-nya simple, gini:

```markdown
_💬 \[nama personil\]: <message>_
```

atau

```markdown
_&#128172; \[nama personil\]: <message>_
```

atau yaudah repot amat pake escape sama italic. gini aja udah.

```markdown
💬 [nama personil]
<message>
```

Contohnya gini

```markdown
**Problem:** CPU Spike Alert kelewat buat di-monitor dan diinfoin ke client.
**Proposed Solution:** 
1. Bikin mekanisme snooze, yang mana ketika belom ada action yang di-acknowledge, Alert akan muncul terus
_💬 \[Sung Jin-Woo\]: Hai gess, tolong provide at least 3 proposed solutions._
```

Jadinya gini

**Problem:** CPU Spike Alert kelewat buat di-monitor dan diinfoin ke client.
**Proposed Solution:** 
1. Bikin mekanisme snooze, yang mana ketika belom ada action yang di-acknowledge, Alert akan muncul terus
_💬 \[Sung Jin-Woo\]: Hai gess, tolong provide at least 3 proposed solutions._

Atau gini

```markdown
**Problem:** CPU Spike Alert kelewat buat di-monitor dan diinfoin ke client.
**Proposed Solution:** 
1. Bikin mekanisme snooze, yang mana ketika belom ada action yang di-acknowledge, Alert akan muncul terus
💬 [Sung Jin-Woo]
Hai gess, tolong provide at least 3 proposed solutions.
```

Jadi gini

**Problem:** CPU Spike Alert kelewat buat di-monitor dan diinfoin ke client.
**Proposed Solution:** 
1. Bikin mekanisme snooze, yang mana ketika belom ada action yang di-acknowledge, Alert akan muncul terus
💬 [Sung Jin-Woo]
Hai gess, tolong provide at least 3 proposed solutions.