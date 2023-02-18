---
tags:
- Concept
- Thoughts
- Web-API
date: 2023-12-07
---

# Setup API Gateway

## AWS API Gateway Setup

1. <ins>Create a Lambda function:</ins>
   1. Login ke AWS Lambda console terus pilih "Create  function".
   2. Kasi nama apalah, mungkin "SMS API Gateway" buat "Function name".
   3. Pilih "Create function". By-default function yang dibuat ini bakal return response 200 ke client dengan text "Hello from Lambda!".
2. <ins>Create an HTTP API:</ins>
   1. Bikin HTTP API. API Gateway juga support REST API dan WebSocket API, tapi buat contoh sekarang HTTP API aja dulu.
   2. HTTP API bakal ngasi HTTP endpoint. API Gateway bakal nge-route requests ke Lambda function kita. Terus bakal nge-return response dari function ke client.

Buat AWS bakal butuh AWS account yang punya akses ke AWS IaAM (Identity and Access Management) user console.



## Azure API Gateway Setup

1. <ins>Create a new service:</ins>
   1. Login ke Azure portal. Dari menu, pilih "Create a resource". 
   2. Nanti ada page yang kebuka terus plih "Integration > API Management".
   3. Di page "Create API Management", isi semua settings  terus pilih "Review + create".
2. <ins>Create an API:</ins>
   1. Masuk ke API Management service di Azure portal terus pilih "APIs".
   2. Di sebelah kiri ada menu, terus pilih "+ Add API". Pilih "HTTP" dari list yang ada.



**References:**

- [Getting started with API Gateway - Amazon API Gateway](https://docs.aws.amazon.com/apigateway/latest/developerguide/getting-started.html)
- [API gateway overview | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/api-management-gateways-overview)
- [Quickstart - Create an Azure API Management instance](https://learn.microsoft.com/en-us/azure/api-management/get-started-create-service-instance)
- [Add an API manually using the Azure portal | Microsoft Learn](https://learn.microsoft.com/en-us/azure/api-management/add-api-manually)
- [Prerequisites for getting started with API Gateway](https://docs.aws.amazon.com/apigateway/latest/developerguide/setting-up.html)
- [How to Create an API Proxy Gateway with AWS HTTP API - freeCodeCamp.org](https://www.freecodecamp.org/news/create-an-api-proxy-gateway-with-aws-http-api/)
- [Set up API Gateway with a custom CloudFront distribution](https://repost.aws/knowledge-center/api-gateway-cloudfront-distribution)
- [How to Create API with AWS: API Gateway Tutorial - Netlify](https://www.netlify.com/guides/creating-an-api-with-aws-lambda-dynamodb-and-api-gateway/api-gateway/)
- [API gateways - Azure Architecture Center | Microsoft Learn](https://learn.microsoft.com/en-us/azure/architecture/microservices/design/gateway)
- [Deploy a self-hosted gateway to Azure Kubernetes Service](https://learn.microsoft.com/en-us/azure/api-management/how-to-deploy-self-hosted-gateway-azure-kubernetes-service)
- https://console.aws.amazon.com/lambda