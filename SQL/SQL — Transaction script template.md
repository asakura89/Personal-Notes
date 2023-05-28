---
tags:
- SQL
- Template
- Transaction
date: 2023-05-28
---

# Transaction script template

```sql
BEGIN
    SET NOCOUNT ON
    BEGIN TRAN <TransactionName>

    BEGIN TRY
        DECLARE @@message VARCHAR(MAX)

        -- Put your script here

        COMMIT TRAN <TransactionName>
        SET @@message = 'S|Finish'
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN <TransactionName>
        SET @@message = 'E|' + ERROR_MESSAGE()
    END CATCH

    SET NOCOUNT OFF
    SELECT @@message [Message]
END
```