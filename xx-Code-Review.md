<p>
  <h1 align="center">Kelompok Belajar Bunga Matahari</h1>
  <h3 align="center" style="margin-top: -2em;">Coding sudah seharusnya menyenangkan!</h3>
  <h5 align="center" style="margin-top: -0.5em;">
    <a href="https://github.com/asakura89/BisaCSharp.git">asakura89</a> /
    <a href="https://choosealicense.com/licenses/unlicense/">UNLICENSE</a>
  </h5>
  <!-- use MistyLightWindows theme -->
</p>
<br/>


<p style="display:inline-block;vertical-align:baseline;text-decoration:none;text-transform:uppercase;white-space:nowrap;font-size:20px;font-weight:700;letter-spacing:0;text-transform:none;line-height:20px;background:0 0;color:rgba(17,17,19,.85);padding:0 8px 0 0;background-color:transparent;color:#158df7">
[.Net] Code Review
</p>
<br />

Sebelum mulai, mari tanamkan dalam hati bahwasanya gak ada code yang salah. Karena dia ditulis untuk dijalankan. Yang ada adalah code yang bertentangan dengan standard yang diterapin di Team / Project / Company.



**1. Magic String, Magic Number, Magic Value**

**Penjelasan**

Magic value ini adalah value yang fixed (bukan gak akan berubah, tapi jarang berubah) dengan tipe data apapun. Nilai ini bisa ditaro di constant kalo memang gak pernah berubah. Atau taro di config file. Cara lain bisa juga ditaro di database.

**Contoh kasus**

System login di App yang lagi di-develop pake system Claims. Claims yang dibalikin dari Identity Provider (IDP) punya 3 type. `App.Custom.Claim.Username`, `App.Custom.Claim.Email`, dan `App.Custom.Claim.Role`. Karena 3 type Claim ini gakkan berubah, maka bbisa aja kita taro sbg constant.

```C#
Boolean hasEmailClaim = HttpContext
    .User
    .HasClaim(claim => claim.Type == "App.Custom.Claim.Email");

Boolean hasRoleClaim = HttpContext
    .User
    .HasClaim(claim => claim.Type == "App.Custom.Claim.Role");
```

**Seharusnya**

```C#
public class AppClaim {
    public const String UsernameClaimType = "App.Custom.Claim.Username";
    public const String EmailClaimType = "App.Custom.Claim.Email";
    public const String RoleClaimType = "App.Custom.Claim.Role";
}

Boolean hasEmailClaim = HttpContext
    .User
    .HasClaim(claim => claim.Type == AppClaim.EmailClaimType);
```


**Contoh kasus #2**

App yang lagi di-develop, bisa login dengan 3 cara yang berbeda. OIDC, SAML, dan Custom Claim-based login. Tapi claim yang dibutuhin cuma 3, yaitu Username, Email, dan Role. Maka, value tadi bisa dimasukin ke config / database. Artinya configurable. Dan ada mapping-nya. Masing-masing `ClaimService` bakal punya `GetUsernameClaim` atau `GetEmailClaim` dan `GetRoleClaim`-nya sendiri-sendiri.

```C#
Claim oidcUsernameClaim = new OIDCClaimService().GetUsernameClaim();
Claim samlUsernameClaim = new SAMLClaimService().GetUsernameClaim();

public class OIDCClaimService {
    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.OIDC_Username_ClaimType);

    // . . . omitted . . .
}

public class SAMLClaimService {
    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.SAML_Username_ClaimType);

    // . . . omitted . . .
}

public static class AppConstant {
    public const String OIDC_Username_ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    public const String SAML_Username_ClaimType = "urn:App:Custom:SAML:2.0:Username";
}
```

**Seharusnya**

```C#
Claim oidcUsernameClaim = new OIDCClaimService().GetUsernameClaim();
Claim samlUsernameClaim = new SAMLClaimService().GetUsernameClaim();

public class OIDCClaimService {
    String GetUsernameClaimTypeConfig() => ConfigUtil.GetConfigByKey("App.OIDCClaim.Username"); // misalnya ngebalikin "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"

    public Claim GetUsernameClaim() => GetClaimByType(GetUsernameClaimTypeConfig());

    // . . . omitted . . .
}

public class SAMLClaimService {
    String GetUsernameClaimTypeConfig() => ConfigUtil.GetConfigByKey("App.SAMLClaim.Username"); // misalnya ngebalikin "urn:App:Custom:SAML:2.0:Username"

    public Claim GetUsernameClaim() => GetClaimByType(GetUsernameClaimTypeConfig());

    // . . . omitted . . .
}
```



**2. Menggabungkan constant dalam satu class**

**Penjelasan**

Constant yang digabung dalam 1 class enggak menunjukkan separation of concern. Separation of concern adalah hanya class tertentu yang tau untuk melakukan suatu hal. Misal, ada Edit User, maka class yang punya pengetahuan untuk memodifikasi user ya `UserService` misalnya. Begitupun constant.

Tapi biasanya constant ini enggak berdisi sendiri. Misal ada `UserService` terus ada `UserContant`. Atau ada `DbConstant` atau constant-constant yang lain. Karena biasanya constant ini dipake dengan tujuan yang sejalan dengan class yang manggil constant ini.

**Contoh kasus**

Ada 2 cara mengambil `UsernameClaim`, dengan OIDC atau dengan SAML.

```C#
Claim oidcUsernameClaim = new OIDCClaimService().GetUsernameClaim();
Claim samlUsernameClaim = new SAMLClaimService().GetUsernameClaim();

public class OIDCClaimService {
    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.OIDC_Username_ClaimType);

    // . . . omitted . . .
}

public class SAMLClaimService {
    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.SAML_Username_ClaimType);

    // . . . omitted . . .
}

public static class AppConstant {
    public const String OIDC_Username_ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    public const String SAML_Username_ClaimType = "urn:App:Custom:SAML:2.0:Username";
}
```

**Seharusnya**

```C#
Claim oidcUsernameClaim = new OIDCClaimService().GetUsernameClaim();
Claim samlUsernameClaim = new SAMLClaimService().GetUsernameClaim();

public class OIDCClaimService {
    const String OIDC_Username_ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.OIDC_Username_ClaimType);

    // . . . omitted . . .
}

public class SAMLClaimService {
    const String SAML_Username_ClaimType = "urn:App:Custom:SAML:2.0:Username";

    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.SAML_Username_ClaimType);

    // . . . omitted . . .
}
```



**3. String yang hanya dipanggil sekali**

**Penjelasan**

String yang dipanggil sekali, ghak perlu dijadiin constant. Karena tujuan constant adalah biar gak typo dimana-mana.

**Contoh kasus**

Ada 2 cara mengambil `UsernameClaim`, dengan OIDC atau dengan SAML.

```C#
Claim oidcUsernameClaim = new OIDCClaimService().GetUsernameClaim();
Claim samlUsernameClaim = new SAMLClaimService().GetUsernameClaim();

public class OIDCClaimService {
    const String OIDC_Username_ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.OIDC_Username_ClaimType);

    // . . . omitted . . .
}

public class SAMLClaimService {
    const String SAML_Username_ClaimType = "urn:App:Custom:SAML:2.0:Username";

    public Claim GetUsernameClaim() => GetClaimByType(AppConstant.SAML_Username_ClaimType);

    // . . . omitted . . .
}
```

**Seharusnya**

```C#
Claim oidcUsernameClaim = new OIDCClaimService().GetUsernameClaim();
Claim samlUsernameClaim = new SAMLClaimService().GetUsernameClaim();

public class OIDCClaimService {
    public Claim GetUsernameClaim() => GetClaimByType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");

    // . . . omitted . . .
}

public class SAMLClaimService {
    public Claim GetUsernameClaim() => GetClaimByType("urn:App:Custom:SAML:2.0:Username");

    // . . . omitted . . .
}
```



**4. Linq `.Any()`**

**Penjelasan**

Code `.Count() > 0` atau `.Count() != 0` atau `.Length > 0` atau `.Length != 0`, umum banget untuk nentuin suatu list atau array ada isinya atau enggak. Sah-sah aja. Tapi ada cara lain yang lebih gampang buat dibaca. Pake `.Any()`

**Contoh**

```C#
IList<String> selectedUsernameList = ListBoxUser
    .SelectedItems
    .Select(item => item.Value)
    .ToList();

if (selectedUsernameList.Count != 0)
    return "Users were selected.";

String[] selectedUsernameArray = ListBoxUser
    .SelectedItems
    .Select(item => item.Value)
    .ToArray();

if (selectedUsernameArray.Length > 0)
    return "Users were selected.";
```

**Seharusnya**

```C#
IList<String> selectedUsernameList = ListBoxUser
    .SelectedItems
    .Select(item => item.Value)
    .ToList();

if (selectedUsernameList.Any())
    return "Users were selected.";

String[] selectedUsernameArray = ListBoxUser
    .SelectedItems
    .Select(item => item.Value)
    .ToArray();

if (selectedUsernameArray.Any())
    return "Users were selected.";
```



**5. `using namespace`**

**Penjelasan**

Kadang ada aja developer yang kebiasaan manggil class beserta namespace-nya. Ya gak salah. Tapi jadi bikin panjang code-nya jadi makin ke kana aja. Dan harus scroll-scroll.

**Contoh**

```C#
System.Data.DataTable employeData = employeeService.GetAllEmployeeData();
```

**Seharusnya**

```C#
using System.Data;

DataTable employeData = employeeService.GetAllEmployeeData();
```



**6. Pemanggilan method langsung di flow control**

**Penjelasan**

Ini bakal bikin hasil dari method tersebut gak bisa di-debug dengan gampang. Dan kalo nama method-nya panjang bisa jadi sulit dibaca logic-nya.

**Contoh**

```C#
if (new EmployeeService().GetAllEmployeeData() != null) {
    // . . . omitted . . .
}
else if (new EmployeeService().GetAllEmployeeData().Rows.Count() > 0) {
    // . . . omitted . . .
}
```

Selain dari `.GetAllEmployeeData()` dipanggil 2x, class `EmployeeService` juga di-create 2x. Kalo operasi ini memakan resource, apakah CPU, RAM, atau log running task, ya bakal ngaruh banget ke performance dari App.

**Seharusnya**

```C#
var employeeService = new EmployeeService();
DataTable employeeData = employeeService.GetAllEmployeeData();

if (employeeData != null) {
    // . . . omitted . . .
}
else if (employeData.Rows.Count() > 0) {
    // . . . omitted . . .
}
```



**7. Penamaan lambda parameter**

**Penjelasan**

Ini adalah contoh paling banyak kejadiannya. Nama parameter yang umum dipake biasanya `x`, `fld`, `field`.

**Contoh**

```C#
String contactName = dbContext
    .ContactList
    .Where(x => x.CreatedDate < new DateTime(2021, 12, 1))
    .FirstOrDefault(fld => fld.Name);
```

**Seharusnya**

```C#
String contactName = dbContext
    .ContactList
    .Where(contact => contact.CreatedDate < new DateTime(2021, 12, 1))
    .FirstOrDefault(contact => contact.Name);
```



**8. Logic control flow / predicate yang terlalu panjang**

**Penjelasan**

Antara gunakan maksimal hanya 2 predicate dalam 1 control flow atau parameter yang menerima predicate untuk mengurangi kompleksit. Atau boleh di-enter ke bawah untuk readability.

**Contoh**

```C#
IEnumerable<String> contacts = dbContext
    .ContactList
    .Where(contact => contact.CreatedDate < new DateTime(2021, 12, 1) && contact.Email.Contains("@orenosaito.co.jp") && contact.Name[0].ToLower().Equals("a"))
    .Select(contact => contact.Name);

if (contacts != null && contacts.Count() != 0 && contacts.Count() > 0) {
    // . . . omitted . . .
}
```

**Seharusnya**

```C#
IEnumerable<String> contacts = dbContext
    .ContactList
    .Where(contact =>
        contact.CreatedDate < new DateTime(2021, 12, 1) &&
        contact.Email.Contains("@orenosaito.co.jp") &&
        contact.Name[0].ToLower().Equals("a"))
    .Select(contact => contact.Name);

Boolean isntNull = contacts != null;
Boolean hasItems = contacts.Any();
if (isntNull && hasItems) {
    // . . . omitted . . .
}
```

**Atau**

```C#
Func<Contact, Boolean> createdBeforeDec2021 = contact => contact.CreatedDate < new DateTime(2021, 12, 1);
Func<Contact, Boolean> isOreNoSaitoContacts = contact.Email.Contains("@orenosaito.co.jp");
Func<Contact, Boolean> isStartsFromA = contact.Name[0].ToLower().Equals("a");

IEnumerable<String> contacts = dbContext
    .ContactList
    .Where(contact =>
        createdBeforeDec2021 &&
        isOreNoSaitoContacts &&
        isStartsFromA)
    .Select(contact => contact.Name);

Boolean isntNull = contacts != null;
Boolean hasItems = contacts.Any();
if (isntNull && hasItems) {
    // . . . omitted . . .
}
```

**Atau**

```C#
Func<Contact, Boolean> createdBeforeDec2021 = contact => contact.CreatedDate < new DateTime(2021, 12, 1);
Func<Contact, Boolean> isOreNoSaitoContacts = contact.Email.Contains("@orenosaito.co.jp");
Func<Contact, Boolean> isStartsFromA = contact.Name[0].ToLower().Equals("a");
Func<Contact, Boolean> contactsPredicate = contact =>
    createdBeforeDec2021(contact) &&
    isOreNoSaitoContacts(contact) &&
    isStartsFromA(contact);

IEnumerable<String> contacts = dbContext
    .ContactList
    .Where(contactsPredicate)
    .Select(contact => contact.Name);

Boolean isntNull = contacts != null;
Boolean hasItems = contacts.Any();
Boolean validContacts = isntNull && hasItems;
if (validContacts) {
    // . . . omitted . . .
}
```



**9. Penggabungan String yang panjang**

**Penjelasan**

Dynamic String adalah kewajiban. Dan umum banget dimana-mana. Menaggulanginya bisa dengan 2 cara, string interpolation (c# 6 ke atas) atau `StringBuilder`. Ini untuk meningkatkan readability. Walaupun sebenernya udah ada `String.Format` tapi untuk readability masih lebih baik string interpolation.

**Contoh**

```C#
String apiUrl = "https://api.orenosaito.co.jp/" + apiVersion + "/user/" + userId;
```

**Atau**

```C#
String apiUrl = String.Format("https://api.orenosaito.co.jp/{0}/user/{1}", apiVersion, userId);
```

**Seharusnya**

```C#
String apiUrl = $"https://api.orenosaito.co.jp/{apiVersion}/user/{userId}";
```

**Contoh lain**

```C#
String errorMessage = "Operation cannot be carried out becaus of: " + reason + ", by user: " + username + " with role: " + role + "\r\nOriginal exception was: " + ex.Message + "with stack trace: " + ex.StackTrace;
```

**Seharusnya**

```C#
String errorMessage = new StringBuilder()
    .Append($"Operation cannot be carried out becaus of: {reason}")
    .Append($", by user: {username} with role: {role}")
    .AppendLine()
    .Append($"Original exception was: {ex.Message}")
    .Append($" with stack trace: {ex.StackTrace}")
    .ToString();
```



