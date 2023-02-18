---
tags:
- Javascript
- Regex
date: 2024-10-16
---

# Replace Markdown Link

Search Regex: `<u><a href="([^"]+)">(.+)</a></u>`

Replace Regex: `[$2]($1)`

Code:

```javascript
let sentences = `
Source: Conversation with Copilot, 6/2/2024

1. <u><a href="https://go.dev/wiki/Well-known-struct-tags">Go<span class="ag-soft-line-break"></span> Wiki: Well-known struct tags - The Go Programming Language</a></u>
2. <u><a href="https://stackoverflow.com/questions/10858787/what-are-the-uses-for-struct-tags-in-go">What<span class="ag-soft-line-break"></span> are the use(s) for struct tags in Go? - Stack Overflow</a></u>
3. <u><a href="https://v1.gorm.io/docs/models.html">Declaring<span class="ag-soft-line-break"></span> Models | GORM - The fantastic ORM library for Golang, aims to ...</a></u>
4. <u><a href="https://towardsdev.com/struct-tag-golang-edbdb5023f82">Struct<span class="ag-soft-line-break"></span> tags in Golang | Towards Dev</a></u>
5. <u><a href="https://pkg.go.dev/reflect">reflect package - reflect - Go Packages</a></u>
6. <u><a href="https://pkg.go.dev/">https://pkg.go.dev</a></u>
7. <u><a href="https://pkg.go.dev/encoding/xml">xml package - encoding/xml - Go Packages</a></u>
8. <u><a href="https://pkg.go.dev/encoding/json">json package - encoding/json - Go Packages</a></u>
9. <u><a href="https://pkg.go.dev/encoding/asn1">asn1 package - encoding/asn1 - Go Packages</a></u>
10. <u><a href="https://pkg.go.dev/gopkg.in/reform.v1">reform package - gopkg.in/reform.v1 - Go Packages</a></u>
11. <u><a href="https://docs.aws.amazon.com/sdk-for-go/api/service/dynamodb/dynamodbattribute/">dynamodbattribute - Amazon Web Services - Go SDK</a></u>
12. <u><a href="https://pkg.go.dev/cloud.google.com/go/bigquery">bigquery package - cloud.google.com/go/bigquery - Go Packages</a></u>
13. <u><a href="https://pkg.go.dev/cloud.google.com/go/datastore">datastore package - cloud.google.com/go/datastore - Go Packages</a></u>
14. <u><a href="https://pkg.go.dev/cloud.google.com/go/spanner">spanner package - cloud.google.com/go/spanner - Go Packages</a></u>
15. <u><a href="https://pkg.go.dev/go.mongodb.org/mongo-driver/bson">bson package - go.mongodb.org/mongo-driver/bson - Go Packages</a></u>
16. <u><a href="https://pkg.go.dev/github.com/jinzhu/gorm">gorm package - github.com/jinzhu/gorm - Go Packages</a></u>
17. <u><a href="https://pkg.go.dev/gopkg.in/yaml.v2">yaml package - gopkg.in/yaml.v2 - Go Packages</a></u>
18. <u><a href="https://pkg.go.dev/github.com/pelletier/go-toml">toml package - github.com/pelletier/go-toml - Go Packages</a></u>
19. <u><a href="https://github.com/go-playground/validator">GitHub - go-playground/validator: :100:Go Struct and Field validation, including Cross Field, Cross Struct, Map, Slice and Array diving</a></u>
20. <u><a href="https://pkg.go.dev/github.com/mitchellh/mapstructure">mapstructure package - github.com/mitchellh/mapstructure - Go Packages</a></u>
21. <u><a href="https://pkg.go.dev/github.com/alecthomas/participle">participle package - github.com/alecthomas/participle - Go Packages</a></u>
22. <u><a href="https://github.com/golang/protobuf">GitHub - golang/protobuf: Go support for Google&amp;#39;s protocol buffers</a></u>
23. <u><a href="https://github.com/jmoiron/sqlx">GitHub - jmoiron/sqlx: general purpose extensions to golang&amp;#39;s database/sql</a></u>
24. <u><a href="https://github.com/google/go-querystring">GitHub - google/go-querystring: go-querystring is Go library for encoding structs into URL query strings.</a></u>age - github.com/alecthomas/participle - Go Packages</a></u>
`;
let matching = sentences.match(/<u><a href="([^"]+)">(.+)<\/a><\/u>/gm);

console.log(matching === null ? null : matching[0]);
console.table(matching);

let replaced = sentences.replace(/<u><a href="([^"]+)">(.+)<\/a><\/u>/gm, "[$2]($1)");

console.log(replaced);
```

Output-nya

```markdown
<u><a href="https://go.dev/wiki/Well-known-struct-tags">Go<span class="ag-soft-line-break"></span> Wiki: Well-known struct tags - The Go Programming Language</a></u>
┌───────┬───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│ (idx) │ Values                                                                                                                                                                                                                                │
├───────┼───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤
│     0 │ '<u><a href="https://go.dev/wiki/Well-known-struct-tags">Go<span class="ag-soft-line-break"></span> Wiki: Well-known struct tags - The Go Programming Language</a></u>'                                                               │
│     1 │ '<u><a href="https://stackoverflow.com/questions/10858787/what-are-the-uses-for-struct-tags-in-go">What<span class="ag-soft-line-break"></span> are the use(s) for struct tags in Go? - Stack Overflow</a></u>'                       │
│     2 │ '<u><a href="https://v1.gorm.io/docs/models.html">Declaring<span class="ag-soft-line-break"></span> Models | GORM - The fantastic ORM library for Golang, aims to ...</a></u>'                                                        │
│     3 │ '<u><a href="https://towardsdev.com/struct-tag-golang-edbdb5023f82">Struct<span class="ag-soft-line-break"></span> tags in Golang | Towards Dev</a></u>'                                                                              │
│     4 │ '<u><a href="https://pkg.go.dev/reflect">reflect package - reflect - Go Packages</a></u>'                                                                                                                                             │
│     5 │ '<u><a href="https://pkg.go.dev/">https://pkg.go.dev</a></u>'                                                                                                                                                                         │
│     6 │ '<u><a href="https://pkg.go.dev/encoding/xml">xml package - encoding/xml - Go Packages</a></u>'                                                                                                                                       │
│     7 │ '<u><a href="https://pkg.go.dev/encoding/json">json package - encoding/json - Go Packages</a></u>'                                                                                                                                    │
│     8 │ '<u><a href="https://pkg.go.dev/encoding/asn1">asn1 package - encoding/asn1 - Go Packages</a></u>'                                                                                                                                    │
│     9 │ '<u><a href="https://pkg.go.dev/gopkg.in/reform.v1">reform package - gopkg.in/reform.v1 - Go Packages</a></u>'                                                                                                                        │
│    10 │ '<u><a href="https://docs.aws.amazon.com/sdk-for-go/api/service/dynamodb/dynamodbattribute/">dynamodbattribute - Amazon Web Services - Go SDK</a></u>'                                                                                │
│    11 │ '<u><a href="https://pkg.go.dev/cloud.google.com/go/bigquery">bigquery package - cloud.google.com/go/bigquery - Go Packages</a></u>'                                                                                                  │
│    12 │ '<u><a href="https://pkg.go.dev/cloud.google.com/go/datastore">datastore package - cloud.google.com/go/datastore - Go Packages</a></u>'                                                                                               │
│    13 │ '<u><a href="https://pkg.go.dev/cloud.google.com/go/spanner">spanner package - cloud.google.com/go/spanner - Go Packages</a></u>'                                                                                                     │
│    14 │ '<u><a href="https://pkg.go.dev/go.mongodb.org/mongo-driver/bson">bson package - go.mongodb.org/mongo-driver/bson - Go Packages</a></u>'                                                                                              │
│    15 │ '<u><a href="https://pkg.go.dev/github.com/jinzhu/gorm">gorm package - github.com/jinzhu/gorm - Go Packages</a></u>'                                                                                                                  │
│    16 │ '<u><a href="https://pkg.go.dev/gopkg.in/yaml.v2">yaml package - gopkg.in/yaml.v2 - Go Packages</a></u>'                                                                                                                              │
│    17 │ '<u><a href="https://pkg.go.dev/github.com/pelletier/go-toml">toml package - github.com/pelletier/go-toml - Go Packages</a></u>'                                                                                                      │
│    18 │ '<u><a href="https://github.com/go-playground/validator">GitHub - go-playground/validator: :100:Go Struct and Field validation, including Cross Field, Cross Struct, Map, Slice and Array diving</a></u>'                             │
│    19 │ '<u><a href="https://pkg.go.dev/github.com/mitchellh/mapstructure">mapstructure package - github.com/mitchellh/mapstructure - Go Packages</a></u>'                                                                                    │
│    20 │ '<u><a href="https://pkg.go.dev/github.com/alecthomas/participle">participle package - github.com/alecthomas/participle - Go Packages</a></u>'                                                                                        │
│    21 │ '<u><a href="https://github.com/golang/protobuf">GitHub - golang/protobuf: Go support for Google&amp;#39;s protocol buffers</a></u>'                                                                                                  │
│    22 │ '<u><a href="https://github.com/jmoiron/sqlx">GitHub - jmoiron/sqlx: general purpose extensions to golang&amp;#39;s database/sql</a></u>'                                                                                             │
│    23 │ '<u><a href="https://github.com/google/go-querystring">GitHub - google/go-querystring: go-querystring is Go library for encoding structs into URL query strings.</a></u>age - github.com/alecthomas/participle - Go Packages</a></u>' │
└───────┴───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘

Source: Conversation with Copilot, 6/2/2024

1. [Go<span class="ag-soft-line-break"></span> Wiki: Well-known struct tags - The Go Programming Language](https://go.dev/wiki/Well-known-struct-tags)
2. [What<span class="ag-soft-line-break"></span> are the use(s) for struct tags in Go? - Stack Overflow](https://stackoverflow.com/questions/10858787/what-are-the-uses-for-struct-tags-in-go)
3. [Declaring<span class="ag-soft-line-break"></span> Models | GORM - The fantastic ORM library for Golang, aims to ...](https://v1.gorm.io/docs/models.html)
4. [Struct<span class="ag-soft-line-break"></span> tags in Golang | Towards Dev](https://towardsdev.com/struct-tag-golang-edbdb5023f82)
5. [reflect package - reflect - Go Packages](https://pkg.go.dev/reflect)
6. [https://pkg.go.dev](https://pkg.go.dev/)
7. [xml package - encoding/xml - Go Packages](https://pkg.go.dev/encoding/xml)
8. [json package - encoding/json - Go Packages](https://pkg.go.dev/encoding/json)
9. [asn1 package - encoding/asn1 - Go Packages](https://pkg.go.dev/encoding/asn1)
10. [reform package - gopkg.in/reform.v1 - Go Packages](https://pkg.go.dev/gopkg.in/reform.v1)
11. [dynamodbattribute - Amazon Web Services - Go SDK](https://docs.aws.amazon.com/sdk-for-go/api/service/dynamodb/dynamodbattribute/)
12. [bigquery package - cloud.google.com/go/bigquery - Go Packages](https://pkg.go.dev/cloud.google.com/go/bigquery)
13. [datastore package - cloud.google.com/go/datastore - Go Packages](https://pkg.go.dev/cloud.google.com/go/datastore)
14. [spanner package - cloud.google.com/go/spanner - Go Packages](https://pkg.go.dev/cloud.google.com/go/spanner)
15. [bson package - go.mongodb.org/mongo-driver/bson - Go Packages](https://pkg.go.dev/go.mongodb.org/mongo-driver/bson)
16. [gorm package - github.com/jinzhu/gorm - Go Packages](https://pkg.go.dev/github.com/jinzhu/gorm)
17. [yaml package - gopkg.in/yaml.v2 - Go Packages](https://pkg.go.dev/gopkg.in/yaml.v2)
18. [toml package - github.com/pelletier/go-toml - Go Packages](https://pkg.go.dev/github.com/pelletier/go-toml)
19. [GitHub - go-playground/validator: :100:Go Struct and Field validation, including Cross Field, Cross Struct, Map, Slice and Array diving](https://github.com/go-playground/validator)
20. [mapstructure package - github.com/mitchellh/mapstructure - Go Packages](https://pkg.go.dev/github.com/mitchellh/mapstructure)
21. [participle package - github.com/alecthomas/participle - Go Packages](https://pkg.go.dev/github.com/alecthomas/participle)
22. [GitHub - golang/protobuf: Go support for Google&amp;#39;s protocol buffers](https://github.com/golang/protobuf)
23. [GitHub - jmoiron/sqlx: general purpose extensions to golang&amp;#39;s database/sql](https://github.com/jmoiron/sqlx)
24. [GitHub - google/go-querystring: go-querystring is Go library for encoding structs into URL query strings.</a></u>age - github.com/alecthomas/participle - Go Packages](https://github.com/google/go-querystring)
```

