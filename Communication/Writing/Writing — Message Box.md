---
tags:
- Writing
- Research
- Concept
- Markdown
date: 2022-11-20
---

# Message Box

## Simple markdown

Mencontek punya [Microsoft Learn](https://learn.microsoft.com/en-us/contribute/markdown-reference#alerts-note-tip-important-caution-warning "Markdown reference for Microsoft Learn - Contributor guide | Microsoft Learn"), bisa dipake buat simple message box.

```markdown
> ❗ Note
> 
> Information the user should notice even if skimming.

> 💡 Tip
> 
> Optional information to help a user be more successful.

> ❗❗ Important
> 
> Essential information required for user success.

> ❌ Caution
> 
> Negative potential consequences of an action.

> ⚠️ Warning
>
> Dangerous certain consequences of an action.
```

jadinya gini

> ❗ Note
> 
> Information the user should notice even if skimming.

> 💡 Tip
> 
> Optional information to help a user be more successful.

> ❗❗ Important
> 
> Essential information required for user success.

> ❌ Caution
> 
> Negative potential consequences of an action.

> ⚠️ Warning
>
> Dangerous certain consequences of an action.



buat announcement bisa gini sepertinya

```markdown
> 📢 Announcement
> 
> General Announcement

> 🙌 Good News
> 
> Good news announcement
```

jadinya gini

> 📢 Announcement
> 
> General Announcement

> 🙌 Good News
> 
> Good news announcement

Ternyata dibahas juga di github-flavored markdown disini ([\[Markdown\] An option to highlight a &#34;Note&#34; and &#34;Warning&#34; using blockquote (Beta) · community · Discussion #16925 \(github.com\)](https://github.com/orgs/community/discussions/16925#discussioncomment-2827410))



## CSS-based

yang pake css ini dicontek dari [Kube UI Framework 7](https://github.com/imperavi/kubeframework) dengan modifikasi (under license [MIT](https://github.com/imperavi/kubeframework/blob/master/LICENSE.md) [ygy](_ "ya gaes ya")).

<div style="font-size:0.9375em;font-weight:500;text-transform:none;padding:16px 32px 16px 16px;box-shadow:none;border:1px solid rgba(17,17,19,0.1);border-radius:4px;position:relative;margin-bottom:16px;background:#f3f3f3;color:rgba(17,17,19,.85)">
❗ Alert
<br/>
Information the user should notice even if skimming.
</div>

<div style="font-size:0.9375em;font-weight:500;text-transform:none;padding:16px 32px 16px 16px;box-shadow:none;border:1px solid rgba(17,17,19,0.1);border-radius:4px;position:relative;margin-bottom:16px;background:rgba(238,36,85,0.07);border-color:rgba(238,36,85,0.3);color:#ee2455;">
❌ Error alert
<br/>
Negative potential consequences of an action.
</div>

<div style="font-size:0.9375em;font-weight:500;text-transform:none;padding:16px 32px 16px 16px;box-shadow:none;border:1px solid rgba(17,17,19,0.1);border-radius:4px;position:relative;margin-bottom:16px;background:rgba(32,188,113,0.07);border-color:rgba(32,188,113,0.3);color:#20bc71;">
👍 Success alert
<br/>
Information the user should notice even if skimming.
</div>

<div style="font-size:0.9375em;font-weight:500;text-transform:none;padding:16px 32px 16px 16px;box-shadow:none;border:1px solid rgba(17,17,19,0.1);border-radius:4px;position:relative;margin-bottom:16px;background:rgba(21,141,247,0.07);border-color:rgba(21,141,247,0.3);color:#158df7;">
🎯 Focus alert
<br/>
Information the user should notice even if skimming.
</div>

<div style="font-size:0.9375em;font-weight:500;text-transform:none;padding:16px 32px 16px 16px;box-shadow:none;border:1px solid rgba(17,17,19,0.1);border-radius:4px;position:relative;margin-bottom:16px;background:rgba(255,105,81,0.07);border-color:rgba(255,105,81,0.3);color:#ff6951;">
⚠️ Warning alert
<br/>
Dangerous certain consequences of an action.
</div>
