---
tags:
- Javascript
- Regex
date: 2023-12-02
---

# Common Password

Regex: `^(?:(?:[0-9]+[a-zA-Z]+)+|(?:[a-zA-Z]+[0-9]+)+|[a-zA-Z]+|[0-9]+|(?:.*?pass.+|.*?p@ss.+|.*?word.+|.*?w0rd.+|.*?fuck.+|.*?pussy.+|.*?asshole.+|ass.+))$`

Code:

```javascript
let matchedCommonPass = [
    "0000", "000000", "1111", "11111", "111111",
    "11111111", "112233", "121212", "123123", "123123123",
    "123321", "1234", "12345", "123456", "1234567",
    "12345678", "123456789", "1234567890", "1234qwer", "123654",
    "123qwe", "131313", "159753", "2000", "222222",
    "333333", "555555", "654321", "666666", "6969",
    "696969", "777777", "7777777", "88888888", "987654",
    "987654321", "999999", "aaaaaa", "abc123", "access",
    "admin", "amanda", "andrea", "andrew", "anthony",
    "arsenal", "ashley", "asshole", "austin", "bailey",
    "banana", "baseball", "batman", "bigdog", "biteme",
    "booboo", "boomer", "boston", "brandon", "bulldog",
    "buster", "camaro", "charlie", "cheese", "chelsea",
    "chester", "chicken", "coffee", "compaq", "computer",
    "cookie", "corvette", "cowboy", "cowboys", "dakota",
    "dallas", "daniel", "diablo", "diamond", "dragon",
    "eagles", "edward", "falcon", "ferrari", "football",
    "forever", "freedom", "fuck", "fucker", "fuckme",
    "fuckoff", "fuckyou", "gateway", "george", "ginger",
    "golfer", "guitar", "hammer", "hannah", "hardcore",
    "harley", "heather", "hello", "hockey", "hunter",
    "iceman", "iloveyou", "internet", "jackson", "jennifer",
    "jessica", "johnny", "jordan", "joseph", "joshua",
    "junior", "justin", "killer", "klaster", "lakers",
    "letmein", "london", "love", "maggie", "marina",
    "martin", "master", "matrix", "matthew", "maverick",
    "melissa", "mercedes", "merlin", "michael", "michelle",
    "mickey", "miller", "money", "monkey", "monster",
    "morgan", "mother", "mustang", "nascar", "nicole",
    "oliver", "orange", "p@ss*w0rd", "p@ss*word", "pass",
    "pass*w0rd", "pass*word", "password", "patrick", "peanut",
    "pepper", "phoenix", "porsche", "princess", "purple",
    "pussy", "q1w2e3r4", "q1w2e3r4t5", "qwer1234", "qwerty",
    "qwertyuiop", "ranger", "richard", "robert", "samantha",
    "samsung", "scooby", "scooter", "secret", "sexy",
    "shadow", "silver", "smokey", "snoopy", "soccer",
    "sparky", "spider", "starwars", "steelers", "summer",
    "sunshine", "superman", "taylor", "tennis", "test",
    "thomas", "thunder", "tigers", "tigger", "trustno1",
    "welcome","whatever","william","xxxxxx","yamaha",
    "yankees", "yellow"
]
.map(item => {
    let matching = item
        .trim()
        .match(/^(?:(?:[0-9]+[a-zA-Z]+)+|(?:[a-zA-Z]+[0-9]+)+|[a-zA-Z]+|[0-9]+|(?:.*?pass.+|.*?p@ss.+|.*?word.+|.*?w0rd.+|.*?fuck.+|.*?pussy.+|.*?asshole.+|ass.+))$/g);

    return matching !== null;
});

console.log(matchedCommonPass.filter(item => item === false));
```

Outputnya

```javascript
[]
```


```javascript
[Experimental]
^(?:(?:[0-9]+[a-zA-Z]+)+|(?:[a-zA-Z]+[0-9]+)+|[a-zA-Z]+|[a-zA-Z]{,8}+|[0-9]+|[0-9]{,8}+|(?:.*?pass.+|.*?p@ss.+|.*?word.+|.*?w0rd.+|.*?fuck.+|.*?pussy.+|.*?asshole.+|ass.+))$

[Experimental]
(?:[0-9].*){1,}?(?:[a-zA-Z].*?){1,}?|(?:[a-zA-Z].*?){1,}?(?:[0-9].*?){1,}?
```