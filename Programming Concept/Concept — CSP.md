---
tags:
- Research
- Concept
date: 2023-05-26
---

# CSP

{Content}

<!--

CSP (Content Security Policy) is a security feature that helps prevent cross-site scripting (XSS) and other code injection attacks. It can be implemented using either a hash or a token (nonce).

A **hash** of a script or style can be used to allow it. You can compute the SHA-256 hash of your entire JavaScript code block and add the hash to your script-src directive to allow it to execute via your Content-Security-Policy header². However, if you need to allow several inline scripts (or styles), all those IDs can add clutter to your policy. Every time you make a change to your inline script, you’ll need to update your CSP³.

On the other hand, a **nonce** is a randomly generated string that is only used once. The nonce needs to be generated dynamically and must be different for each request, so you need to generate the CSP header programmatically⁴. An advantage of using a nonce over a hash is that the nonce is smaller than the hash so the header size will be smaller⁴.

Would you like more information on this topic?

Source: Conversation with Bing, 5/26/2023(1) CSP Hash Examples and Guide - Content-Security-Policy. https://content-security-policy.com/hash/ Accessed 5/26/2023.
(2) Allowing inline scripts in your Content Security Policy using a hash .... https://www.bryanbraun.com/2021/08/10/allowing-inline-scripts-in-your-content-security-policy-using-a-hash/ Accessed 5/26/2023.
(3) CSP Nonce Examples and Guide - Content-Security-Policy. https://content-security-policy.com/nonce/ Accessed 5/26/2023.
(4) Correctly using hash with content security policy (CSP). https://stackoverflow.com/questions/65106785/correctly-using-hash-with-content-security-policy-csp Accessed 5/26/2023.



The choice between using a hash or a nonce for implementing CSP depends on your specific use case and requirements.

If you have a small number of inline scripts or styles that do not change frequently, using a hash might be a good option. It is quick and simple to implement, and you can define the header in the web server since it does not change.

However, if you have several inline scripts or styles, or if they change frequently, using a nonce might be a better approach. The nonce is smaller than the hash so the header size will be smaller. Additionally, you won't need to update your CSP every time you make a change to your inline script.

Ultimately, it's up to you to weigh the pros and cons of each approach and decide which one is the best fit for your needs.



Sure! Here are examples of how to use a hash and a nonce with CSP:

**Using a hash with CSP:**
Suppose you have the following script on your page:
```html
<script>
  doSomething();
</script>
```
You can compute the SHA-256 hash of your entire JavaScript code block (in this case, it is just `doSomething();`) and add the hash to your script-src directive to allow it to execute via your Content-Security-Policy header. For example:
```
Content-Security-Policy: script-src 'sha256-RFWPLDbv2BY+rCkDzsE+0fr8ylGr2R2faWMhq4lfEQc=';
```
The easiest way to generate the hash is to open the developer tools console and it will output what the expected hash of your script was in the console error message.

**Using a nonce with CSP:**
Suppose you have the following script on your page:
```html
<script nonce="EDNnf03nceIOfn39fn3e9h3sdfa">
  doSomething();
</script>
```
You can generate a random nonce value for each request and include it in your script tag as well as in your script-src directive. For example:
```
Content-Security-Policy: script-src 'nonce-EDNnf03nceIOfn39fn3e9h3sdfa';
```
Remember that the nonce needs to be generated dynamically and must be different for each request.

I hope these examples help clarify how to use a hash and a nonce with CSP!



-->


