---
tags:
- Javascript
date: 2024-04-11
---

# Please accept

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

function decode(str) {
    var j;
    var hexes = str.match(/.{1,4}/g) || [];
    var back = "";
    for(j = 0; j<hexes.length; j++) {
        back += String.fromCharCode(parseInt(hexes[j], 16));
    }
    return back;
}

function run() {
    var year = new State(1444);
    var reaction = function(stateValue) {
        console.log(decode("00480061007000700079002000450069006400200041006c002d00460069007400720020") +
            stateValue +
            decode("0048002e00200050006c006500610073006500200061006300630065007000740020007400680069007300200068006500610072007400660065006c0074002000610070006f006c006f00670079002e00200048006f00700069006e006700200066006f007200200064006f006f00720020006f006600200066006f00720067006900760065006e0065007300730020007700690074006800200061006c006c0020006d007900200068006500610072007400200061006e006400200073006f0075006c00200066006f007200200061006e0079002000770072006f006e00670064006f0069006e006700730020004900270076006500200063006f006d006d0069007400740065006400200061006e00640020006d0069007300740061006b00650073002000490027007600650020006d006100640065002e"));
    };

    year.onChange(reaction);
    year.value++;
}

run();
```

Minify pake [Minify JS Online. JavaScript Minification tool that works in browser. | Minify JS Online (minify-js.com)](https://minify-js.com/)

```javascript
function State(e){this.__value__=e,this.__listeners__=[]}function decode(e){var t,n=e.match(/.{1,4}/g)||[],o="";for(t=0;t<n.length;t++)o+=String.fromCharCode(parseInt(n[t],16));return o}function run(){var e=new State(1444);e.onChange((function(e){console.log(decode("00480061007000700079002000450069006400200041006c002d00460069007400720020")+e+decode("0048002e00200050006c006500610073006500200061006300630065007000740020007400680069007300200068006500610072007400660065006c0074002000610070006f006c006f00670079002e00200048006f00700069006e006700200066006f007200200064006f006f00720020006f006600200066006f00720067006900760065006e0065007300730020007700690074006800200061006c006c0020006d007900200068006500610072007400200061006e006400200073006f0075006c00200066006f007200200061006e0079002000770072006f006e00670064006f0069006e006700730020004900270076006500200063006f006d006d0069007400740065006400200061006e00640020006d0069007300740061006b00650073002000490027007600650020006d006100640065002e"))})),e.value++}State.prototype.onChange=function(e){this.__listeners__.push(e)},State.prototype.notifyChange=function(e){this.__listeners__.forEach((function(t){t(e)}))},Object.defineProperty(State.prototype,"value",{get:function(){return this.__value__},set:function(e){this.__value__!==e&&(this.__value__=e,this.notifyChange(e))}}),run();
```

Hand tweaked

```javascript
function st(e){this._v=e,this._l=[]}function dc(e){var t,n=e.match(/.{1,4}/g)||[],o="";for(t=0;t<n.length;t++)o+=String.fromCharCode(parseInt(n[t],16));return o}function r(){var e=new st(1444);e.oc((function(e){console.log(dc("00480061007000700079002000450069006400200041006c002d00460069007400720020")+e+dc("0048002e00200050006c006500610073006500200061006300630065007000740020007400680069007300200068006500610072007400660065006c0074002000610070006f006c006f00670079002e00200048006f00700069006e006700200066006f007200200064006f006f00720020006f006600200066006f00720067006900760065006e0065007300730020007700690074006800200061006c006c0020006d007900200068006500610072007400200061006e006400200073006f0075006c00200066006f007200200061006e0079002000770072006f006e00670064006f0069006e006700730020004900270076006500200063006f006d006d0069007400740065006400200061006e00640020006d0069007300740061006b00650073002000490027007600650020006d006100640065002e"))})),e.value++}st.prototype.oc=function(e){this._l.push(e)},st.prototype.nc=function(e){this._l.forEach((function(t){t(e)}))},Object.defineProperty(st.prototype,"value",{get:function(){return this._v},set:function(e){this._v!==e&&(this._v=e,this.nc(e))}}),r();
```

