---
tags:
- Concept
date: 2024-11-24
---

# Programming to Abstraction

dengan interface dirimu bisa punya code gini

```c#
public void GetDataFromDatabase(IConnection connection) {
    connection.Connect();
    
    /* get data */
    
    connection.Disconnect();
}
```

terus inject aja mau pake MySQL atau SQL code works tanpa ngerubah apa-apa

tapi kalo tanpa interface, bisa jadi nama method-nya beda. cara akses sama cara panggil data beda
bayangin code-nya gini

```c#
public void GetDataFromDatabase(MySQLConnection connection) {
    connection.Connect();

    /* get data */

    connection.Disconnect();
}
```

mau di-update kaya gini

```c#
public void GetDataFromDatabase(SQLConnection connection) {
    connection.OpenConnection();

    /* get data */

    connection.CloseConnection();
}
```

jadi ngeganti code dirimu
atau kalo `Connection` itu dipake ditempat lain, ya ganti juga code-nya

ini pake teknik programming to abstraction
fungsi buat bisa gampang di-inject buat implemen dependency injection terus bisa gampang di-test pake unit test