---
tags:
- Javascript
- Regex
date: 2024-07-17
---

# Cleanup HTML attribute

Search Regex: `(div) class="[^"]+"`

Replace Regex: `$1`

Tag-nya bisa ganti-ganti
- div
- table
- tr
- td
- etc.

attribute-nya juga bisa ganti
- class
- style

Kalo mau nyari berdasarkan attribute-nya gak peduli tag-nya, bisa gini

Search Regex: `<(.+) data-.+="[^"]+"`

Replace Regex: `<$1`