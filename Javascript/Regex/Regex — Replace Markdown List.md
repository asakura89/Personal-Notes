---
tags:
- Javascript
- Regex
date: 2024-06-18
---

# Replace Markdown List

Search Regex: `^(\s{1,})?\* `

Replace Regex: `$1- `

Code:

```javascript
let sentences = `
Ini harusnya Change Request
* Mereka bikin banner manual. Artinya kemungkinan besar ngedit file code (aspx) langsung di server dan gak lewat code canges
* Pertanyaannya, mereka mau pake design maintenance banner yang mana? Yang mereka edit manual atau ada design baru yang memang design proper
* Mesti ngecek apakah maintenance banner ini global atau enggak
* Karena perubahannya simple, kita ada options buat gak charge mereka quarter ini.
  * Mau di-waive kah?
  * Mau di-include as part of other big CR 
    * Kenapa? Biar effort SIT dan Deployment (Staging dan Prod) itu nyatu sama CR yang gedenya
    * Berarti saking simplenya gadak UAT 
    * CR tersendiri tapi yang di-charge cuma effort development doang. SIT, deployment, sama UAT dianggap sbg bagian dari maintenance 
`;
let matching = sentences.match(/^(\s{1,})?\* /gm);

console.log(matching === null ? null : matching[0]);
console.table(matching);

let replaced = sentences.replace(/^(\s{1,})?\* /gm, "$1- ");

console.log(replaced);
```

Output-nya

```markdown
* 
┌─────────┬──────────┐
│ (index) │  Values  │
├─────────┼──────────┤
│    0    │   '* '   │
│    1    │   '* '   │
│    2    │   '* '   │
│    3    │   '* '   │
│    4    │  '  * '  │
│    5    │  '  * '  │
│    6    │ '    * ' │
│    7    │ '    * ' │
│    8    │ '    * ' │
└─────────┴──────────┘

Ini harusnya Change Request
- Mereka bikin banner manual. Artinya kemungkinan besar ngedit file code (aspx) langsung di server dan gak lewat code canges
- Pertanyaannya, mereka mau pake design maintenance banner yang mana? Yang mereka edit manual atau ada design baru yang memang design proper
- Mesti ngecek apakah maintenance banner ini global atau enggak
- Karena perubahannya simple, kita ada options buat gak charge mereka quarter ini.
  - Mau di-waive kah?
  - Mau di-include as part of other big CR 
    - Kenapa? Biar effort SIT dan Deployment (Staging dan Prod) itu nyatu sama CR yang gedenya
    - Berarti saking simplenya gadak UAT 
    - CR tersendiri tapi yang di-charge cuma effort development doang. SIT, deployment, sama UAT dianggap sbg bagian dari maintenance 
```


Cara alternative

```javascript
let sentences = `
**Opinions:**
Ini harusnya Change Request
* Mereka bikin banner manual. Artinya kemungkinan besar ngedit file code (aspx) langsung di server dan gak lewat code canges
* Pertanyaannya, mereka mau pake design maintenance banner yang mana? Yang mereka edit manual atau ada design baru yang memang design proper
* Mesti ngecek apakah maintenance banner ini global atau enggak
* Karena perubahannya simple, kita ada options buat gak charge mereka quarter ini.
  *  Mau di-waive kah?
  *  Mau di-include as part of other big CR 
    *  Kenapa? Biar effort SIT dan Deployment (Staging dan Prod) itu nyatu sama CR yang gedenya
    *  Berarti saking simplenya gadak UAT 
    *  CR tersendiri tapi yang di-charge cuma effort development doang. SIT, deployment, sama UAT dianggap sbg bagian dari maintenance 
`;
let matching = sentences.match(/^(\s{1,})?\*{1}([^\*](\s{1,})?)/gm);

console.log(matching === null ? null : matching[0]);
console.table(matching);

let replaced = sentences.replace(/^(\s{1,})?\*{1}([^\*](\s{1,})?)/gm, "$1-$2");

console.log(replaced);
```

Output-nya

```markdown
* 
┌─────────┬───────────┐
│ (index) │  Values   │
├─────────┼───────────┤
│    0    │   '* '    │
│    1    │   '* '    │
│    2    │   '* '    │
│    3    │   '* '    │
│    4    │  '  *  '  │
│    5    │  '  *  '  │
│    6    │ '    *  ' │
│    7    │ '    *  ' │
│    8    │ '    *  ' │
└─────────┴───────────┘

**Opinions:**
Ini harusnya Change Request
- Mereka bikin banner manual. Artinya kemungkinan besar ngedit file code (aspx) langsung di server dan gak lewat code canges
- Pertanyaannya, mereka mau pake design maintenance banner yang mana? Yang mereka edit manual atau ada design baru yang memang design proper
- Mesti ngecek apakah maintenance banner ini global atau enggak
- Karena perubahannya simple, kita ada options buat gak charge mereka quarter ini.
  -  Mau di-waive kah?
  -  Mau di-include as part of other big CR 
    -  Kenapa? Biar effort SIT dan Deployment (Staging dan Prod) itu nyatu sama CR yang gedenya
    -  Berarti saking simplenya gadak UAT 
    -  CR tersendiri tapi yang di-charge cuma effort development doang. SIT, deployment, sama UAT dianggap sbg bagian dari maintenance 
```

