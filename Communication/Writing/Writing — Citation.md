---
tags:
- Writing
- Format
- Markdown
date: 2022-11-20
---

# Citation

Di markdown ada quote tapi gak ada cara yang enak buat nge-_cite_.

Muter-muter Stackoverflow nemu <ins>[ini](https://stackoverflow.com/questions/2002120/citing-the-author-of-a-blockquote-using-markdown-syntax "citations - Citing the author of a blockquote using Markdown syntax - Stack Overflow")</ins>, tapi banyak versi. Ada non-stackoverflow juga yang <ins>[ini](https://whatismarkdown.com/how-to-have-citations-in-markdown-2/ "How To Have Citations In Markdown? – What Is Mark Down")</ins> sama ini <ins>[ini](https://v4.chriskrycho.com/2015/academic-markdown-and-citations.html "Academic Markdown and Citations · Chris Krycho")</ins>

Akhirnya saia putuskan buat make yang dari stackoverflow.

```markdown
> I need a "Hello, world." program by this afternoon.
>
> — <cite>[Senior Manager][0]</cite>

[0]: https://www.smart-jokes.org/programmer-evolution.html
```

jadinya gini

> I need a "Hello, world." program by this afternoon.
>
> — <cite>[Senior Manager][0]</cite>

[0]: https://www.smart-jokes.org/programmer-evolution.html