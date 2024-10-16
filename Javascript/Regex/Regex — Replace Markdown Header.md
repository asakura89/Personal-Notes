---
tags:
- Javascript
- Regex
date: 2024-10-16
---

# Replace Markdown Header

Search Regex: `^#### (.+)`

Replace Regex: `##### <ins>$1</ins>`

Code:

```javascript
let sentences = `
### 1. Things to Handover to the Next Team Lead

#### a. Ongoing Projects and Tasks

#### b. Team Dynamics and Individual Strengths

#### c. Tools and Processes

### 2. Things to Teach Him About the Position

#### a. Leadership and Communication Skills

#### b. Time Management and Prioritization

#### c. Motivating and Supporting the Team

### Opinions
`;
let matching = sentences.match(/^#### (.+)/gm);

console.log(matching === null ? null : matching[0]);
console.table(matching);

let replaced = sentences.replace(/^#### (.+)/gm, "##### <ins>$1</ins>");

console.log(replaced);
```

Output-nya

```markdown
#### a. Ongoing Projects and Tasks
┌───────┬──────────────────────────────────────────────────┐
│ (idx) │ Values                                           │
├───────┼──────────────────────────────────────────────────┤
│     0 │ "#### a. Ongoing Projects and Tasks"             │
│     1 │ "#### b. Team Dynamics and Individual Strengths" │
│     2 │ "#### c. Tools and Processes"                    │
│     3 │ "#### a. Leadership and Communication Skills"    │
│     4 │ "#### b. Time Management and Prioritization"     │
│     5 │ "#### c. Motivating and Supporting the Team"     │
└───────┴──────────────────────────────────────────────────┘

### 1. Things to Handover to the Next Team Lead

##### <ins>a. Ongoing Projects and Tasks</ins>

##### <ins>b. Team Dynamics and Individual Strengths</ins>

##### <ins>c. Tools and Processes</ins>

### 2. Things to Teach Him About the Position

##### <ins>a. Leadership and Communication Skills</ins>

##### <ins>b. Time Management and Prioritization</ins>

##### <ins>c. Motivating and Supporting the Team</ins>

### Opinions
```

