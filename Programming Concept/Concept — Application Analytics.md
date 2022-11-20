---
tags:
- Research
- Concept
- Unfinished-note
date: 2022-07-22
---

# Application Analytics

## Google analytics / Web analytics concept

**Link**

1. https://developers.google.com/analytics/resources/concepts/gaConceptsTrackingOverview
2. https://developers.google.com/analytics/devguides/collection/gajs/eventTrackerGuide
3. https://developers.google.com/analytics/devguides/collection/gajs/gaTrackingEcommerce
4. https://developers.google.com/analytics/devguides/collection/gajs/methods/gaJSApiEcommerce#_gat.GA_Tracker_._addItem
5. https://developers.google.com/analytics/devguides/collection/gajs/gaTrackingCustomVariables#visitorLevel
6. https://stackoverflow.com/questions/391979/how-to-get-clients-ip-address-using-javascript



## Concept

### Data

1. User data

    1. Http request —  hostname, browser type, referrer, language

    2. Browser and system information — above infos plus screen resolution

    3. First-party cookies
2. Interaction data / event category
    1. Page — page view / page open event interaction
    2. Event – btn submit click, share facebook, share instagram, download user manual, download vaccinated location
    3. Widget — page widget interaction
    4. File downloads
    5. Purchase transaction — SKU, prod name, prod category, price, qty, local currency — can be associate it to certain page by triggering web page interaction
3. Non-interaction data
    1. Id of event / data, event / data name, value, any other associated data / page



Data visitor kurang lebih kaya gini

```
$id;
$uuid;
$httpAcceptLanguage;
$clientUserAgent;
$clientScreenSize
$remoteAddr;
$createdAt;
```



### Code

```javascript
// Initialize engine
var analytics = new Analytics("<app_name> or <app_identifier>");

// Track page view
analytics.visit();

// Track page but overrides the url
// e.g. visit https://tofunojura.com/shop/register#final-step
analytics.visit("https://tofunojura.com/shop/register");

analytics.visit({
    url: "https://tofunojura.com/shop/register",
    section: "final-step"
});

// callback
analytics.visit("https://tofunojura.com/shop/register", () => {
  console.log("callback");
});

analytics.visit(() => {
  console.log("callback");
});

// callback in every method, not just visit

// Track custom event
analytics.track("<event_name>");

analytics.track("form_submit_clicked");

analytics.track("cart_add", {
    price: 20,
    item: "microsoft 365 subscription",
    sku: "sku-number",
    qty: 2
});

// Identify a visitor
analytics.identify("<user_identifier>", {
  firstName: "juragan",
  lastName: "tahu",
  email: "tofu.no.jura.1457@gmail.com"
})

// Identify visitor with additional profile
analytics.identify("<user_identifier>", {
  name: "juragan tahu",
  company: "Tofu no Jura Inc."
})

// Get current user
var user = analytics.user();

// Get specific user
var user = analytics.user("<user_identifier>");

// Reset current visitor
analytics.reset();
```


client ip can't be recorded by client script
need geoip db
doesnt matter, just use the visitor id




> [https://codeconcerns.com/dimensions-segments-metrics-sitecore-experience-analytics/](https://codeconcerns.com/dimensions-segments-metrics-sitecore-experience-analytics/ "https://codeconcerns.com/dimensions-segments-metrics-sitecore-experience-analytics/")

> **Tracker** → fitur dari analytics yang punya method atau api buat nge-record semua interaction termasuk page visit oleh visitor
>         **Visitor** → user yang di-record/di-track dan disimpen sbg contact, apakah anonymous atau identified. kalo identified biasanya ada email-nya. apakah dia login, atau dia input email seawaktu subscribe
> **Interaction** → hal yang dilakuin user di website / device yang dipasangi tracker. biasanya interaction ini lebih kaya hal-hal yang dilakuin dalam satu waktu.
> misal, ada user buka google.com di 1 tab. selama tab itu gak di-close akan di-record sebagai 1 interaction. di dalam interaction akan ada banyak **Page Event**. klik button kah, buka link kah, download kah, visit sebuah url kah.
> **Personalization** → biasanya user/visitor/contact main identifier-nya adalah email (kalo identified). kalo anonymous, maka analytics bakal ngelakuin **profiling** / **fingerprinting** si user anonymous ini.
> gimana caranya?
> contact punya **dimensions** namanya. dimension ini adalah data kecil banget (atomic) yang dipake buat mengidentifikasi suatu contact. user agent dari browser, ip address, browser window/tab size, jenis device kalo bisa kedetect, negara yang diambil dari ip, dan hal lain yang bisa dipake buat nge-identify user.
> kalo user-nya udah di identify, kita bisa bikin 1 set aturan-aturan / rule yang bisa diterapin ke user tertentu. misal, gue bikin 1 rule personalization kalo ada user yang keranjang belanjaannya isinya elektronik yang masuk kategori hape. munculin pop up hape-hape top 10 paling laku.
