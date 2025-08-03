---
tags:
- Typescript
date: 2025-08-03
---

# Overload

<ins>Overload</ins> di typescript <ins>gak bisa enggak urutan</ins>, harus urutan

```javascript
class Duration {
    readonly millis: number;

    private static readonly MillisPerSecond = 1000;
    private static readonly MillisPerMinute = 60 * Duration.MillisPerSecond;
    private static readonly MillisPerHour = 60 * Duration.MillisPerMinute;
    private static readonly MillisPerDay = 24 * Duration.MillisPerHour;

    constructor();
    constructor(milliseconds: number);
    constructor(seconds: number, milliseconds: number);
    constructor(minutes: number, seconds: number, milliseconds: number);
    constructor(hours: number, minutes: number, seconds: number, milliseconds: number);
    constructor(days: number, hours: number, minutes: number, seconds: number, milliseconds: number);
    constructor(days: number = 0, hours: number = 0, minutes: number = 0, seconds: number = 0, milliseconds: number = 0) {
        this.millis = days * Duration.MillisPerDay +
            hours * Duration.MillisPerHour +
            minutes * Duration.MillisPerMinute +
            seconds * Duration.MillisPerSecond +
            milliseconds;
    }

    static fromMilliseconds(ms: number): Duration {
        return new Duration(ms);
    }

    get days() {
        return Math.floor(this.millis / Duration.MillisPerDay);
    }

    get hours() {
        return Math.floor((this.millis / Duration.MillisPerHour) % 24);
    }

    get minutes() {
        return Math.floor((this.millis / Duration.MillisPerMinute) % 60);
    }

    get seconds() {
        return Math.floor((this.millis / Duration.MillisPerSecond) % 60);
    }

    get milliseconds() {
        return Math.floor(this.millis % 1000);
    }
}

const d = Duration.fromMilliseconds(5);
console.log(d);
console.table({
    d: d.days,
    h: d.hours,
    m: d.minutes,
    s: d.seconds,
    ms: d.milliseconds
});
```

Output-nya

```javascript
Duration { millis: 432000000 }
┌─────────┬────────┐
│ (index) │ Values │
├─────────┼────────┤
│ d       │ 5      │
│ h       │ 0      │
│ m       │ 0      │
│ s       │ 0      │
│ ms      │ 0      │
└─────────┴────────┘
```

liat gak jadi 5 hari
dan milisekonnya jadi ngaco
padahal mau input 5 ms doang

tapi kalo paramnya urutan, `.fromMilliseconds`-nya mesti dibenerin


```javascript
class Duration {
    readonly millis: number;

    private static readonly MillisPerSecond = 1000;
    private static readonly MillisPerMinute = 60 * Duration.MillisPerSecond;
    private static readonly MillisPerHour = 60 * Duration.MillisPerMinute;
    private static readonly MillisPerDay = 24 * Duration.MillisPerHour;

    constructor();
    constructor(days: number);
    constructor(days: number, hours: number);
    constructor(days: number, hours: number, minutes: number);
    constructor(days: number, hours: number, minutes: number, seconds: number);
    constructor(days: number, hours: number, minutes: number, seconds: number, milliseconds: number);
    constructor(days: number = 0, hours: number = 0, minutes: number = 0, seconds: number = 0, milliseconds: number = 0) {
        this.millis = days * Duration.MillisPerDay +
            hours * Duration.MillisPerHour +
            minutes * Duration.MillisPerMinute +
            seconds * Duration.MillisPerSecond +
            milliseconds;
    }

    static fromMilliseconds(ms: number): Duration {
        return new Duration(0, 0, 0, 0, ms);
    }

    get days() {
        return Math.floor(this.millis / Duration.MillisPerDay);
    }

    get hours() {
        return Math.floor((this.millis / Duration.MillisPerHour) % 24);
    }

    get minutes() {
        return Math.floor((this.millis / Duration.MillisPerMinute) % 60);
    }

    get seconds() {
        return Math.floor((this.millis / Duration.MillisPerSecond) % 60);
    }

    get milliseconds() {
        return Math.floor(this.millis % 1000);
    }
}

const d = Duration.fromMilliseconds(5);
console.log(d);
console.table({
    d: d.days,
    h: d.hours,
    m: d.minutes,
    s: d.seconds,
    ms: d.milliseconds
});
```

```javascript
Duration { millis: 5 }
┌─────────┬────────┐
│ (index) │ Values │
├─────────┼────────┤
│ d       │ 0      │
│ h       │ 0      │
│ m       │ 0      │
│ s       │ 0      │
│ ms      │ 5      │
└─────────┴────────┘
```

