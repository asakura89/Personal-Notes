---
tags:
- IIS
date: 2023-06-21
---

# Max URL Length

{Content}

<!-- 
## User
Hi Bing, I want to ask about how IIS count the URL length in context RequestLimits?
## Bing
The <requestLimits> element specifies limits on HTTP requests that are processed by the Web server. These limits include the maximum size of a request, the maximum URL length, and the maximum length for a query string. In addition, the <requestLimits> element can contain a collection of user-defined HTTP header limits in the <headerLimits> element, which allows you to define custom settings on HTTP headers.
When request filtering blocks an HTTP request because an HTTP request exceeds the request limits, IIS will return an HTTP 404 error to the client and log one of the following HTTP statuses with a unique substatus that identifies the reason that the request was denied: HTTP Substatus Description 404.14 URL Too Long.
Is there anything else you would like to know?
## User
the how IIS count URL length and query string length? for example this URL: https://forms.office.com/Pages/ResponsePage.aspx?id=j6yBwAtt9Eis5Nwau53hjkRoUhDJ_zdNlwedKvvVwoBURTJTR1JKTkcwMzhaR0lWT0tPT0EyNUI3Vi4u&origin=Invitation&channel=1
## Bing
In IIS, the URL length is counted as the number of characters in the URL, including the protocol (e.g., https://) and any query string parameters. In your example, the URL length would be 191 characters.
The query string length is counted as the number of characters after the ? symbol in the URL. In your example, the query string length would be 136 characters.
Is there anything else you would like to know?
## User
how about query string separator? the & symbol. is it counted?
## Bing
Yes, the & symbol is counted as part of the query string length. In your example, the query string length would still be 136 characters, including the & symbols.
Is there anything else you would like to know?
## User
then for URL, is query string also counted?
## Bing
Yes, the query string is also counted as part of the URL length. In your example, the URL length would be 191 characters, including the query string.
Is there anything else you would like to know?
## User
in URL is the domain counted?
## Bing
Yes, the domain is counted as part of the URL length. In your example, the URL length would be 191 characters, including the domain forms.office.com.
Is there anything else you would like to know?

-->