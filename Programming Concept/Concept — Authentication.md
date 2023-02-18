---
tags:
- Research
- Concept
date: 2023-01-18
---

# Authentication

## Basic

Identity and Access Management is the security discipline that
enables the right individuals to access the right resources at the
right time for the right reasons. There are two words that can
picture Identity and Access Management. Those are Authentication and
Authorization. Authentication or referred as AuthN, is the act of
proving who you are. Authorization or referred as AuthZ, is the act
of granting you access.

Typical Enterprise Identity and Access Management usually need a user
store that is often based on Active Directory. The technology used
mostly was LDAP. In more advanced scenarios, many applications use
web-based SSO with custom implementations. As web applications move
to the SaaS architecture nowadays, or a Software as a Service, a
federation was needed. These are based-on standards and you can
integrate apps or services from many vendors.



## Local Identity and Access Management

In the early days of development, developers created a user store
within the application. If a new application is created, then a new
user store within that application will be created. Many user stores
will result in redundant information and at the user level it will
result in password reuse thus weakening the security. And if a user
leaves the company, the administrator needs to disable or remove that
specific user from each of the applications.



## Claim-based Identity and Access Management

With the claim-based access, the developer replaces the
authentication logic in the application with simpler logic that can
accept claims. When authenticated, the application and the source of
authentication and authorization established a trust. This source of
authentication and authorization is often called as Identity Provider
or IDP.

The application will still have a local user store for user settings
and access rights but the application doesn't have to handle the
passwords because the users authenticate into the Identity Provider
instead of the application.

When a user wants to access the application, the IDP will generate a
claim or an access token to be sent to the application. And all
applications can accept claims issued by a single IDP. So any changes
to the AuthN logic will be done on the IDP side. No modifications
will be made in the applications. If a user leaves the company, the
administrator can just disable from one place and immediately all
accesses to all applications will be revoked. And once the user is
authenticated, the user can access all the applications that
established trust with the IDP.

So what is a claim? A claim is an attribute of a user that is brought
by the user to be used in the application. Let say the user has 3
attributes, a username, an email address, and a role. All
applications that established a trust with the IDP, will receive
these attributes or claims. That’s why the application might still
need a local user store to manage these attributes to be used as user
AuthZ.

The main topic of claim-based access is a trust. How the IDP and the
applications establish a trust depends on the standards used by the
developer. Several standards are certificate exchange, metadata
exchange, or use Client Id and Secret.

If the developer uses metadata exchange, the application and the IDP
needs to share with each other a file or a link to a file that
contains the certificate, login and logout urls, or other parameters.
If the developer doesn’t use metadata exchange, usually the
certificate, login and logout urls as well as other parameters, need
to be input manually can be through url or through an HTTP Header for
a web application.

Sometimes the developer doesn’t use a certificate, instead a
username and password are used.



## Realm or Security domain

A Realm is a circle of trust. Within the realm each component trusts
each other and claims are used to provide access to systems. If there
are multiple realms, by default they don’t have a trust between
each other. So users in realm A can’t use their claims issued by
their local IDP to gain access to applications in realm B. Vice
versa. To do this you need a Federation.

With Federation, users can use their own local IDP for AuthN then
access applications in other realms. The user administration is
handled within each realm. If a user in realm B doesn’t need access
to realm A anymore, then administrator of realm B disables the user
without telling or notifying the administrator of realm A and the
user will lose all access.



## Level of Assurance

Trust other realms means we need to validate the Level of Assurance
(LOA). In other words, how other realms processes, systems, users and
administrators can be trusted and validated. This information can be
included as a claim itself. Let say we, the user in realm A, need to
trust the user in realm B. Then as a Level of Assurance, users in
realm A need to include claims that stated how they are
authenticated.  Are they authenticated through just a username and
password pair? Or do they also add another layer with MFA (Multi
Factor Authentication)? If they have several layer authentication,
then we can assure that their LOA is quite high. But if they just
authenticated through a username and password pair. Then their LOA is
quite low and we can redirect back the user to their home realm with
a message to do another authentication process in order to elevate
their LOA.



## Tenant Discovery

Federation that consist of  many different entities we must have a
method to identify the home realm of the user, this often referred to
as Tenant Discovery. The easiest example is when we authenticate
using Azure AD or our Office 365 account, the Office 365 will perform
Tenant Discovery by our company email address. This tells Office 365
which tenant we belong to and what Federation configuration that we
have. Other ways to perform Tenant Discovery was offering a custom
unique URL for each tenant. Or using a user prompt. User prompt is
the most common one to be used because basically the developer just
provides a button which will prompt with some kind of authentication
pop up.

For example, we use some ticketing system that can be accessed both
by our company’s employees to check on new requests or new bug
reports and external parties to report a new bug or request new
features. These two types of users have different home realm and
federation configuration. When authentication is needed, our
ticketing system will perform Tenant Discovery to redirect the
authentication to each type of user’s home realm then IDP on their
home realm will issue claims to be used by our ticketing system.



## Typical content of the claim

There are different standards regarding claims which means the claims
can contain many different things. But at least a unique user
identifier must be included. Of course the claims need to be signed
with IDP’s certificate to avoid the information in the claims being
tampered. In some cases we can have information about whether the
user managed to successfully authenticate or not. Also we can have
information about the method of authentication included as an LOA.
Other common things that are included in the claims are user
attributes like email, first name, last name, and roles.



## Claim Transformation

Sometimes the application didn’t need a unique user identifier,
instead the application will need email and roles. This scenario will
occur if we use a chained federation which will involve multiple IDPs
from different realms. Let say we want to access an application in
realm B and authenticate through our home realm, realm A. From realm
A, we authenticate using username and password then our home realm
IDP issued claims that consist of username, email, manager, manager’s
email, membership group. When we hop into realm B IDP our claims get
terminated and new claims issued which consist of username, email,
roles, membership group. Then the claims forwarded to the
application. In chained federation, the claims that get trusted are
the last claims forwarded to the application.



# OAuth 2.0

## Basic

to provide delegated authority



## Access Token

To access resources



## Refresh Token

To request new Access Token



## Resource Owner (RO)

is User



## Client

is the App that accessed by User



## Authorization Server (AS)

is to login. Once authenticated AS provides Access Token and Refresh Token. Both tokens sent to client. If Access Token is expired, Refresh Token sent to AS to request new Access Token.



## Resource Server (RS)

contains resources protected behind login. To access the resources, client attaches Access Token to RS.



## Server-to-Server delegated authority

Client (Server 1) must provide a name or identifier of the App and callback url/uri to send tokens to. And register both name and callback uri in the AS (Server 2). AS must provide Client Id and Secret.

When user access the Client, client will redirect to AS url with client id, response_type = code, and scope attached in the request. response_type = code means Client wanted and request an authorization code. scope is the type of authorization granted to the client or in other words the resource that wanted to be accessed by the client. e.g. scope = edit_content.



## Front Channel

Client redirect to AS through user's browser to request an Authorization Code.



## Back Channel

When the Authorization Code received, Authorization Code sent to AS to receive an Access Token via Server-to-Server integration.



## Standardization

1. Does not include specific form of token, just specify that it must be a string value
2. Does not include list fo standard scope. Vendors can add their own standard.



# OIDC (OpenID Connect)

## Basic

Add Standardization on top of the OAuth 2.0
1. ID Token must be JWT
2. What claims must be included in the ID Token

UserInfo Endpoint

OpenID Discovery to expose the configuration to help the integration (delegated authority)



## Relying Party (RP)

because it relies on a claim for user authentication (Client is act as an RP). RP or Client need to specify the OpenID Profile scope when request for an Authorization Code.



## OIDC Provider

this is AS



## Flow

Flow is the same as OAuth 2.0 standard from Front Channel to Back Channel with difference. When Client send Authorization Code to Provider to get an Access Token, the response received is not just contains an Access Token but also an ID Token. ID Token will contains Claims about the user e.g Subject, which is a unique identifier of the user (maybe email).



**References:**

- [Identity and Access Management: Technical Overview - YouTube](https://www.youtube.com/watch?v=Tcvsefz5DmA)
- [OAuth 2.0 &amp; OpenID Connect (OIDC): Technical Overview - YouTube](https://www.youtube.com/watch?v=rTzlF-U9Y6Y)

