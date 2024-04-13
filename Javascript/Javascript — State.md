---
tags:
- Javascript
date: 2024-04-13
---

# State

Versi javascript dari ini [CSharp — Reactive](/CSharp/CSharp%20—%20Reactive.md)

```javascript
function State(initial) {
    this.__value__ = initial;
    this.__listeners__ = [];
}

State.prototype.onChange = function(listener) {
    this.__listeners__.push(listener);
};

State.prototype.notifyChange = function(newValue) {
    this.__listeners__.forEach(function(listener) {
        listener(newValue);
    });
};

Object.defineProperty(State.prototype, 'value', {
    get: function() {
        return this.__value__;
    },
    set: function(newValue) {
        var oldValue = this.__value__;
        if (oldValue !== newValue) {
            this.__value__ = newValue;
            this.notifyChange(newValue);
        }
    }
});

let reaction = function (value) {
    console.log(`Value changed → ${value}`);
};

let year = new State(1444);
year.onChange(reaction);
year.value += 3;

// Value changed → 1447
```

<!--


/*
function htmlEncode(str) {
    return str.replace(/&/g, '&amp;')
              .replace(/</g, '&lt;')
              .replace(/>/g, '&gt;')
              .replace(/"/g, '&quot;')
              .replace(/'/g, '&#39;');
}

function htmlDecode(encodedStr) {
    var textArea = document.createElement('textarea');
    textArea.innerHTML = encodedStr;
    return textArea.value;
}

function htmlDecode(str) {
    var textArea = document.createElement('textarea');
    textArea.innerHTML = str;
    return textArea.value;
}

function hexEncode(str) {
    var hex, i;
    var result = "";
    for (i=0; i<str.length; i++) {
        hex = str.charCodeAt(i).toString(16);
        result += ("000"+hex).slice(-4);
    }
    return result;
}

function hexDecode(str) {
    var j;
    var hexes = str.match(/.{1,4}/g) || [];
    var back = "";
    for(j = 0; j<hexes.length; j++) {
        back += String.fromCharCode(parseInt(hexes[j], 16));
    }
    return back;
}
*/


-->