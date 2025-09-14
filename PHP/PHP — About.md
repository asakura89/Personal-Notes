---
tags:
- PHP
date: 2025-09-13
---

# About PHP

## Runtime

- [ZendPHP Enterprise | Secured PHP Runtimes | Perforce Zend](https://www.zend.com/products/zendphp-enterprise)
- [PHP: Downloads](https://www.php.net/downloads.php?usage=web&os=windows&osvariant=windows-downloads&version=default)
- [php-runtime/runtime: A home for runtimes.](https://github.com/php-runtime/runtime)
    - [The Runtime Component (Symfony Docs)](https://symfony.com/doc/current/components/runtime.html)
    - [FrankenPHP: the modern PHP app server](https://frankenphp.dev/)
    - [ReactPHP: Event-driven, non-blocking I/O with PHP - ReactPHP](https://reactphp.org/)
    - [Open Swoole: PHP Server with Async IO, Coroutines and Fibers (previously Swoole) | Open Swoole PHP](https://openswoole.com/)
    - [php-pm/php-pm: PPM is a process manager, supercharger and load balancer for modern PHP applications.](https://github.com/php-pm/php-pm)

masing-masing runtime punya karakteristiknya sendiri, tapi gatau symfony apa karakteristiknya. lebih ke karena punya framework jadi bikin runtime sendiri buat optimize framework-nya mungkin



## Big name

- [Enterprise PHP Development Platform | Expert PHP Support | Zend](https://www.zend.com/)
    - ternyata ini semacam tools-nya aja. dan berbayar.
    - framework-nya sendiri gratis: [Home - Zend Framework](https://framework.zend.com/) tapi udah pindah kesini [Home - Laminas Project - Enterprise PHP Framework](https://getlaminas.org/). bukan pindah sih tapi dilanjutin (baca disini: [Endings and Beginnings: Goodbye, and Please Welcome the Laminas Project! - Blog - Zend Framework](https://framework.zend.com/blog/2020-01-24-laminas-launch.html))
- [Symfony, High Performance PHP Framework for Web Development](https://symfony.com/)
    - [What is Symfony](https://symfony.com/what-is-symfony)
    - Symfony Framework: Web framework yang di-built pake Symfony packages
    - Symfony Packages: Semacam mini-lib buat PHP



## Download that worked

- [windows.php.net - /downloads/releases/](https://windows.php.net/downloads/releases/)



## Package Manager

- Package Manager: [Composer](https://getcomposer.org/)
- Package Repository: [Packagist](https://packagist.org/)
- Composer Manual:
    - [PHP: Introduction to Composer - Manual](https://www.php.net/manual/en/install.composer.intro.php)
    - [Basic usage - Composer](https://getcomposer.org/doc/01-basic-usage.md)



## Framework

- Zend/Laminas
- Symfony
- Laravel



## Symfony

Sewaktu setup Symfony pake CLI tool

https://symfony.com/download#step-2-create-new-symfony-applications

`symfony new --webapp my_project`

symfony new-nya manggil tool dari golang. kirain dibikin pake php juga, ternyata enggak

[symfony-cli/commands/local_new.go at main · symfony-cli/symfony-cli](https://github.com/symfony-cli/symfony-cli/blob/main/commands/local_new.go#L386)

disini dia manggil repo `symfony/website-skeleton` ([symfony/skeleton: The Symfony skeleton](https://github.com/symfony/skeleton))

kalo dicari disini ([symfony repositories](https://github.com/orgs/symfony/repositories?type=all&q=skeleton)), sebenernya isinya cuma composer
- [skeleton/composer.json at 7.3 · symfony/skeleton](https://github.com/symfony/skeleton/blob/7.3/composer.json)
- [webapp-pack/composer.json at main · symfony/webapp-pack](https://github.com/symfony/webapp-pack/blob/main/composer.json)

Framework aslinya ada disini ([symfony/symfony: The Symfony PHP framework](https://github.com/symfony/symfony))



## Awesome PHP

- [ziadoz/awesome-php: A curated list of amazingly awesome PHP libraries, resources and shiny things.](https://github.com/ziadoz/awesome-php)
