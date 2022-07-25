---
tags:
- Research
- Concept
date: 2022-07-22
---

# Application Analytics

**Google analytics / Web analytics concept**

**Link**

1. https://developers.google.com/analytics/resources/concepts/gaConceptsTrackingOverview
2. https://developers.google.com/analytics/devguides/collection/gajs/eventTrackerGuide
3. https://developers.google.com/analytics/devguides/collection/gajs/gaTrackingEcommerce
4. https://developers.google.com/analytics/devguides/collection/gajs/methods/gaJSApiEcommerce#_gat.GA_Tracker_._addItem
5. https://developers.google.com/analytics/devguides/collection/gajs/gaTrackingCustomVariables#visitorLevel
6. https://stackoverflow.com/questions/391979/how-to-get-clients-ip-address-using-javascript

**Concept**

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



```javascript
// how to track visitor
function(){
  var readCookie = function(key){
    var result;
	return (result = new RegExp('(?:^|; )' + encodeURIComponent(key) + '=([^;]*)').exec(document.cookie)) ? (result[1]) : null;
  }
  var writeCookie = function(name, value, domain, expire){
    document.cookie = name+"="+value+";domain=."+domain+";path=/;expires="+expire;
  }
  var visitorId = readCookie('v_id');
  var date = new Date();
  if(visitorId === null){
    visitorId = date.getTime().toString(16) + (Math.floor(Math.random() * (999999 - 100000) + 100000)).toString(16);
  }
  date.setTime(date.getTime() + (2 * 365 * 24 * 60 * 60 * 1000));
  writeCookie('v_id', visitorId, location.hostname, new Date(date).toUTCString());
  return visitorId;
}
```

visitor data might contains

```
$id;
$uuid;
$httpAcceptLanguage;
$httpUserAgent;
$remoteAddr;
$createdAt;
```



```javascript
import Analytics from 'analytics'
import googleAnalytics from '@analytics/google-analytics'
import customerIo from '@analytics/customerio'

/* Initialize analytics */
const analytics = Analytics({
  app: 'my-app-name',
  version: 100,
  plugins: [
    googleAnalytics({
      trackingId: 'UA-121991291',
    }),
    customerIo({
      siteId: '123-xyz'
    })
  ]
})

/* Track a page view */
analytics.page()

/* Track a custom event */
analytics.track('userPurchase', {
  price: 20
  item: 'pink socks'
})

/* Identify a visitor */
analytics.identify('user-id-xyz', {
  firstName: 'bill',
  lastName: 'murray',
  email: 'da-coolest@aol.com'
})


/* analytics.identify */
// Basic user id identify
analytics.identify('xyz-123')

// Identify with additional traits
analytics.identify('xyz-123', {
  name: 'steve',
  company: 'hello-clicky'
})

// Fire callback with 2nd or 3rd argument
analytics.identify('xyz-123', () => {
  console.log('do this after identify')
})

// Disable sending user data to specific analytic tools
analytics.identify('xyz-123', {}, {
  plugins: {
    // disable sending this identify call to segment
    segment: false
  }
})

// Send user data to only to specific analytic tools
analytics.identify('xyz-123', {}, {
  plugins: {
    // disable this specific identify in all plugins except customerio
    all: false,
    customerio: true
  }
})

/* analytics.track */
// Basic event tracking
analytics.track('buttonClicked')

// Event tracking with payload
analytics.track('itemPurchased', {
  price: 11,
  sku: '1234'
})

// Fire callback with 2nd or 3rd argument
analytics.track('newsletterSubscribed', () => {
  console.log('do this after track')
})

// Disable sending this event to specific analytic tools
analytics.track('cartAbandoned', {
  items: ['xyz', 'abc']
}, {
  plugins: {
    // disable track event for segment
    segment: false
  }
})

// Send event to only to specific analytic tools
analytics.track('customerIoOnlyEventExample', {
  price: 11,
  sku: '1234'
}, {
  plugins: {
    // disable this specific track call all plugins except customerio
    all: false,
    customerio: true
  }
})

/* analytics.page */
// Basic page tracking
analytics.page()

// Page tracking with page data overrides
analytics.page({
  url: 'https://google.com'
})

// Fire callback with 1st, 2nd or 3rd argument
analytics.page(() => {
  console.log('do this after page')
})

// Disable sending this pageview to specific analytic tools
analytics.page({}, {
  plugins: {
    // disable page tracking event for segment
    segment: false
  }
})

// Send pageview to only to specific analytic tools
analytics.page({}, {
  plugins: {
    // disable this specific page in all plugins except customerio
    all: false,
    customerio: true
  }
})

/* analytics.user */
// Get all user data
const userData = analytics.user()

// Get user id
const userId = analytics.user('userId')

// Get user company name
const companyName = analytics.user('traits.company.name')

/* analytics.reset */
// Reset current visitor
analytics.reset()
```

client ip can't be recorded by client script
need geoip db
doesnt matter, just use the v_id




> [https://codeconcerns.com/dimensions-segments-metrics-sitecore-experience-analytics/](https://codeconcerns.com/dimensions-segments-metrics-sitecore-experience-analytics/ "https://codeconcerns.com/dimensions-segments-metrics-sitecore-experience-analytics/")

> **Tracker** → fitur dari analytics yang punya method atau api buat nge-record semua interaction termasuk page visit oleh visitor
>         **Visitor** → user yang di-record/di-track dan disimpen sbg contact, apakah anonymous atau identified. kalo identified biasanya ada email-nya. apakah dia login, atau dia input email seawaktu subscribe
> **Interaction** → hal yang dilakuin user di website / device yang dipasangi tracker. biasanya interaction ini lebih kaya hal-hal yang dilakuin dalam satu waktu.
> misal, ada user buka google.com di 1 tab. selama tab itu gak di-close akan di-record sebagai 1 interaction. di dalam interaction akan ada banyak **Page Event**. klik button kah, buka link kah, download kah, visit sebuah url kah.
> **Personalization** → biasanya user/visitor/contact main identifier-nya adalah email (kalo identified). kalo anonymous, maka analytics bakal ngelakuin **profiling** / **fingerprinting** si user anonymous ini.
> gimana caranya?
> contact punya **dimensions** namanya. dimension ini adalah data kecil banget (atomic) yang dipake buat mengidentifikasi suatu contact. user agent dari browser, ip address, browser window/tab size, jenis device kalo bisa kedetect, negara yang diambil dari ip, dan hal lain yang bisa dipake buat nge-identify user.
> kalo user-nya udah di identify, kita bisa bikin 1 set aturan-aturan / rule yang bisa diterapin ke user tertentu. misal, gue bikin 1 rule personalization kalo ada user yang keranjang belanjaannya isinya elektronik yang masuk kategori hape. munculin pop up hape-hape top 10 paling laku.
