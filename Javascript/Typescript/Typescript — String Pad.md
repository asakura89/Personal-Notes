---
tags:
- Javascript
- Typescript
- String
date: 2022-12-06
---

# String Pad

## TS Version

```javascript
class StringHelper {
    constructor() { }

    getStringPadding(width: number, pad?: string): string  {
        if (pad === undefined || pad === null) {
            pad = " ";
        }

        var padded = "";
        for(var idx = 0; idx < width; idx++) {
            padded += pad;
        }
        
        return padded;
    }

    padLeft(str: string, width: number): string;
    padLeft(str: string, width: number, pad: string): string;
    padLeft(str: string, width: number, pad?: string): string {
        if (width <= 0) {
            return str;
        }

        var padWidth = width - str.length;
        if (padWidth <= 0) {
            return str;
        }

        var padded = this.getStringPadding(padWidth, pad);
        var resulting = padded + str;
        return (resulting).substring(resulting.length - width, resulting.length);
    }

    padRight(str: string, width: number): string;
    padRight(str: string, width: number, pad: string): string;
    padRight(str: string, width: number, pad?: string): string {
        if (width <= 0) {
            return str;
        }

        var padWidth = width - str.length;
        if (padWidth <= 0) {
            return str;
        }

        var padded = this.getStringPadding(padWidth, pad);
        return (str + padded).substring(0, width);
    }
}
```



## ES5 Version

```javascript
"use strict";
var StringHelper = function () {
    function StringHelper() { }

    StringHelper.prototype.getStringPadding = function (width, pad) {
        if (pad === undefined || pad === null) {
            pad = " ";
        }

        var padded = "";
        for (var idx = 0; idx < width; idx++) {
            padded += pad;
        }

        return padded;
    };

    StringHelper.prototype.padLeft = function (str, width, pad) {
        if (width <= 0) {
            return str;
        }

        var padWidth = width - str.length;
        if (padWidth <= 0) {
            return str;
        }

        var padded = this.getStringPadding(padWidth, pad);
        var resulting = padded + str;

        return resulting
            .substring(
                resulting.length - width,
                resulting.length
            );
    };

    StringHelper.prototype.padRight = function (str, width, pad) {
        if (width <= 0) {
            return str;
        }

        var padWidth = width - str.length;
        if (padWidth <= 0) {
            return str;
        }

        var padded = this.getStringPadding(padWidth, pad);
        return (str + padded)
            .substring(0, width);
    };

    return StringHelper;
}();
```