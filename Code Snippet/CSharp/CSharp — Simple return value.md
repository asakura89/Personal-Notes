---
tags:
- Snippet
- CSharp
date: 2016-01-18
---

# Simple return value

Awalnya return value ini dipake buat return value dari ASP.NET MVC Controller ketika dipanggil jQuery buat render html Partial View atau buat kirim simple data. Tapi ternyata bisa dipake buat banyak kasus.

## Contoh Code

```c#
void Main() {
    var type = new Dictionary<String, String> {
        ["I"] = "Info",
        ["E"] = "Error",
        ["W"] = "Warning",
        ["S"] = "Success"
    };

    var stringB = new StringBuilder();
    GetLogs()
        .Select(str => str.AsActionResponseViewModel(true))
        .ToList()
        .ForEach(arvy => stringB.AppendLine($"{type[arvy.ResponseType]} → {arvy.Message}"));

    Console.WriteLine(stringB.ToString());
}

public IEnumerable<String> GetLogs() {
    yield return "I|Start";
    yield return "I|Get ProcessId ::begin::";
    yield return "I|Get ProcessId ::end::";
    yield return "I|Update unfinish process Log status ::begin::";
    yield return "I|Update unfinish process Log status ::end::";
    yield return "I|Delete data from temp_Item where CreatedBy: user_1 ::begin::";
    yield return "I|Delete data from temp_Item where CreatedBy: user_1 ::end::";
    yield return "I|Delete data from temp_SubItem where CreatedBy: user_1 ::begin::";
    yield return "I|Delete data from temp_SubItem where CreatedBy: user_1 ::end::";
    yield return "I|Delete data from temp_Condition where CreatedBy: user_1 ::begin::";
    yield return "I|Delete data from temp_Condition where CreatedBy: user_1 ::end::";
    yield return "S|Finish: It's an Add process";
    yield return "I|Start";
    yield return "I|Get currency rate ::begin::";
    yield return "I|Get currency rate ::end::";
    yield return "I|Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000107 and ItemNo: 1 ::begin::";
    yield return "I|Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000107 and ItemNo: 1 ::end::";
    yield return "I|Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 1, HeaderNo: 5000000107 and ItemNo: 1 ::begin::";
    yield return "I|Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 1, HeaderNo: 5000000107 and ItemNo: 1 ::end::";
    yield return "I|Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 ::begin::";
    yield return "I|Clean calculation temp data ::begin::";
    yield return "I|Clean calculation temp data ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_1 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_1 ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_25 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_25 ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_2 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_2 ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_3 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_3 ::end::";
    yield return "I|Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 ::end::";
    yield return "I|Get currency rate ::begin::";
    yield return "I|Get currency rate ::end::";
    yield return "I|Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000142 and ItemNo: 1 ::begin::";
    yield return "I|Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000142 and ItemNo: 1 ::end::";
    yield return "I|Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 2, HeaderNo: 5000000142 and ItemNo: 1 ::begin::";
    yield return "I|Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 2, HeaderNo: 5000000142 and ItemNo: 1 ::end::";
    yield return "I|Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 ::begin::";
    yield return "I|Clean calculation temp data ::begin::";
    yield return "I|Clean calculation temp data ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_1 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_1 ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_25 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_25 ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_2 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_2 ::end::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_3 ::begin::";
    yield return "I|Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_3 ::end::";
    yield return "I|Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 ::end::";
    yield return "S|Finish";
    yield return "I|Start";
    yield return "I|Get currency rate ::begin::";
    yield return "I|Get currency rate ::end::";
    yield return "E|37 - Conversion failed when converting the varchar value 'I|Update data in temp_Item where HeaderNo: NULL and ItemNo: ' to data type int.";
}
```

Code retrun value-nya bisa diambil dari sini [[Link]](https://github.com/asakura89/Arvy/blob/4b5927e73493fdee329be145134d4cdbbf86b4f3/ActionResponseViewModel.cs). Return value ini sendiri refer ke code lain untuk handle Exception, yaitu ini [[Link]](https://github.com/asakura89/Exy/blob/2035f620ac1713d3b513e5df0c314ec2f0d0bc02/ExceptionExt.cs).



Output

```markdown
Info → Start
Info → Get ProcessId ::begin::
Info → Get ProcessId ::end::
Info → Update unfinish process Log status ::begin::
Info → Update unfinish process Log status ::end::
Info → Delete data from temp_Item where CreatedBy: user_1 ::begin::
Info → Delete data from temp_Item where CreatedBy: user_1 ::end::
Info → Delete data from temp_SubItem where CreatedBy: user_1 ::begin::
Info → Delete data from temp_SubItem where CreatedBy: user_1 ::end::
Info → Delete data from temp_Condition where CreatedBy: user_1 ::begin::
Info → Delete data from temp_Condition where CreatedBy: user_1 ::end::
Success → Finish: It's an Add process
Info → Start
Info → Get currency rate ::begin::
Info → Get currency rate ::end::
Info → Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000107 and ItemNo: 1 ::begin::
Info → Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000107 and ItemNo: 1 ::end::
Info → Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 1, HeaderNo: 5000000107 and ItemNo: 1 ::begin::
Info → Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 1, HeaderNo: 5000000107 and ItemNo: 1 ::end::
Info → Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 ::begin::
Info → Clean calculation temp data ::begin::
Info → Clean calculation temp data ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_1 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_1 ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_25 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_25 ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_2 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_2 ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_3 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 and PriceCode: TAX_3 ::end::
Info → Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 1 ::end::
Info → Get currency rate ::begin::
Info → Get currency rate ::end::
Info → Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000142 and ItemNo: 1 ::begin::
Info → Select from physic_Item then Insert to temp_Item where HeaderNo: 5000000142 and ItemNo: 1 ::end::
Info → Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 2, HeaderNo: 5000000142 and ItemNo: 1 ::begin::
Info → Select from physic_SubItem then Insert to temp_SubItem where HeaderNo: , SequenceNo: 2, HeaderNo: 5000000142 and ItemNo: 1 ::end::
Info → Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 ::begin::
Info → Clean calculation temp data ::begin::
Info → Clean calculation temp data ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_1 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_1 ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_25 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_25 ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_2 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_2 ::end::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_3 ::begin::
Info → Insert data to temp_Condition where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 and PriceCode: TAX_3 ::end::
Info → Calculating temp_Condition price amount where ActionId: 201601140003 and HeaderNo:  and SequenceNo: 2 ::end::
Success → Finish
Info → Start
Info → Get currency rate ::begin::
Info → Get currency rate ::end::
Error → 37 - Conversion failed when converting the varchar value 'I|Update data in temp_Item where HeaderNo: NULL and ItemNo: ' to data type int.
```