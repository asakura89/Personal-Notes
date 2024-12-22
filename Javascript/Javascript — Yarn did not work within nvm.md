---
tags:
- Javascript
date: 2024-01-14
---

# Yarn did not work within nvm

```shell
cmd> nvm deactivate && nvm uninstall 14.21.3 && nvm install 14.21.3
cmd> npm install -g corepack@0.10.0
cmd> corepack prepare yarn@3.6.4 --activate
cmd> yarn --version
```



**References:**

- https://stackoverflow.com/a/47849940
- [node.js - Can&#39;t uninstall global npm packages after installing nvm - Stack Overflow](https://stackoverflow.com/questions/47763783/cant-uninstall-global-npm-packages-after-installing-nvm#comment83979622_47849940)
