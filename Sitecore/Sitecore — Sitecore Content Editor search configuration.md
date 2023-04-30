---
tags:
- Sitecore
date: 2023-03-30
---

# Sitecore Content Editor search configuration

Berdasarkan official doc:

1. [Sitecore 7.5 official doc](https://doc.sitecore.com/xp/en/legacy-docs/SC75/sitecore-search-and-indexing-guide-sc75-a4.pdf)
   1. Config file-nya `Sitecore.ContentSearch`.
   2. Gak disebutin dan dijelasin berapa default value-nya.
2. [Sitecore 8.2 official doc](https://doc.sitecore.com/xp/en/developers/82/sitecore-experience-platform/walkthrough--setting-up-solr.html#idm45786153472208)
   1. Config file-nya adalah `Sitecore.ContentSearch.config`.
   2. Di official doc ini gak dijelasin berapa default value dari Sc 8.2, mungkin bisa ngecek dari default installation value. Tapi dari official doc ini dikasi contoh sebesar 500. Secara logika, nge-run through 500 search result berasa lelah gak sih? Jadi mungkin 500 atau 100 adalah value yang make sense. Mungkin.
3. [Sitecore 9.2 official doc](https://doc.sitecore.com/xp/en/developers/92/platform-administration-and-architecture/walkthrough--setting-up-solr.html#configure-sitecore-to-work-with-solr)
   1. Sama kaya Sc 8.2, di 9.2 config file-nya juga masih sama di `Sitecore.ContentSearch.config` yang ada di folder `/App_Config/Sitecore/Content Search/`.
   2. Juga sama kaya Sc 8.2, di 9.2 juga gak dijelasin berapa default value-nya. Tapi dari default installation di-set sejuta atau `1000000`. Juga dari official doc dikasi contoh 500. Yang mana masih make sense.
4. [Sitecore 10.1 official doc](https://doc.sitecore.com/xp/en/developers/101/platform-administration-and-architecture/walkthrough--setting-up-solr.html#configure-sitecore-to-work-with-solr)
   1. Config file-nya masih sama dengan yang lain.
   2. Default value-nya disebut sejuta dan bawaan initial installation juga di-set `1000000`.


