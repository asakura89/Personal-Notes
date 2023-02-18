---
tags:
- Design
- Token
- Draft
date: 2023-06-08
---

# Design Token

## What is

Hi Bing, do you know about term "Design Token"?

Yes, I know about Design Tokens. A design token is a design decision: a pairing of the same code and visual properties—design elements you use over and over again in your products—packaged in a format that’s deployable across all platforms. You can create tokens to store visual properties such as color, spacing, line heights, elevation, animation time, etc¹. They were originally developed by Jina Anne at Salesforce⁴. Is there anything else you would like to know about Design Tokens?

Source: Conversation with Bing, 6/8/2023(1) Design Tokens: What they are and how to use them | Inside Design - InVision. https://www.invisionapp.com/inside-design/design-tokens/ Accessed 6/8/2023.
(2) Design Tokens 101 | Dribbble. https://dribbble.com/resources/design-tokens Accessed 6/8/2023.
(3) Design tokens – Material Design 3. https://m3.material.io/foundations/design-tokens/overview Accessed 6/8/2023.
(4) Design tokens - Adobe Inc.. https://spectrum.adobe.com/page/design-tokens/ Accessed 6/8/2023.




## How to create one?

How do I create a design token?

The best way to create a design token is to use a tool such as **Theo** or **Figma Tokens Studio**. You'll be able to create your own token names and store custom design decisions, saving your product design team an untold number of hours². Is there anything else you would like to know?

Source: Conversation with Bing, 6/8/2023(1) Design Tokens 101 | Dribbble. https://dribbble.com/resources/design-tokens Accessed 6/8/2023.
(2) Creating & crafting a design token system - Bootcamp. https://bootcamp.uxdesign.cc/creating-crafting-a-design-token-system-b661a9ba9d55 Accessed 6/8/2023.
(3) Design tokens – Material Design 3. https://m3.material.io/foundations/design-tokens/overview Accessed 6/8/2023.



## Difference with Styleguide

What is the difference between a design token and a style guide?

A style guide is a document that provides guidelines for the way your brand should be presented from both a graphic and language perspective. It includes details such as the color palette, typography, and tone of voice.

On the other hand, design tokens are named entities that store visual design attributes in an agnostic, human-readable abstraction of visual styles that sync with all the style files in the system. This allows you to create a scalable and consistent visual system for UI development³. They represent the small, repeated design decisions that make up a design system's visual style. Tokens replace static values, such as hex codes for color, with self-explanatory names¹.

In summary, a style guide is a document that provides guidelines for how your brand should be presented while design tokens are a tool to help you implement those guidelines consistently across platforms.

Source: Conversation with Bing, 6/8/2023(1) Design Tokens 101 - Design strategy guide. https://designstrategy.guide/design-system/design-tokens-101/ Accessed 6/8/2023.
(2) Design tokens – Material Design 3. https://m3.material.io/foundations/design-tokens/overview Accessed 6/8/2023.
(3) Design Tokens: What they are and how to use them | Inside Design - InVision. https://www.invisionapp.com/inside-design/design-tokens/ Accessed 6/8/2023.


## Example

Can you give me an example of how to use Design Tokens in CSS?


Any token can be used directly in a stylesheet by using the Design Token as a CSS directive. Assuming the token value has been set for the element or some ancestor element, the value of the token embedded in the stylesheet will be the token value for that element instance³.

Here's an example of how you could use design tokens in CSS:

```css
:root {
  --color-primary: #276EE5;
}

.button {
  background-color: var(--color-primary);
}
```

In this example, we define a design token `--color-primary` with a value of `#276EE5` in the `:root` selector. Then, we use this token as a variable in the `.button` selector to set its `background-color` property.

Is there anything else you would like to know?

Source: Conversation with Bing, 6/8/2023(1) Fluent UI Web Components design tokens | Microsoft Learn. https://learn.microsoft.com/en-us/fluent-ui/web-components/design-system/design-tokens Accessed 6/8/2023.
(2) What Are Design Tokens? | CSS-Tricks - CSS-Tricks. https://css-tricks.com/what-are-design-tokens/ Accessed 6/8/2023.
(3) Design Tokens 101 | Dribbble. https://dribbble.com/resources/design-tokens Accessed 6/8/2023.
(4) Design tokens – Material Design 3. https://m3.material.io/foundations/design-tokens/overview Accessed 6/8/2023.




Can you give and example of what is inside design token document would looks like? maybe you can generate some sections, examples, codes. so I can picture it better.

A design token document is a file that contains all the design tokens for a project. It can be in various formats such as JSON, YAML, or SCSS. Here's an example of what a design token document in JSON format might look like:

```json
{
  "color": {
    "primary": "#276EE5",
    "secondary": "#FFC107",
    "success": "#4CAF50",
    "warning": "#FF9800",
    "danger": "#F44336"
  },
  "typography": {
    "font-family": "'Open Sans', sans-serif",
    "font-size": "16px",
    "line-height": "1.5"
  },
  "spacing": {
    "xs": "4px",
    "sm": "8px",
    "md": "16px",
    "lg": "24px",
    "xl": "32px"
  }
}
```

In this example, we have three sections: `color`, `typography`, and `spacing`. Each section contains multiple design tokens with their respective values. For instance, the `color` section contains five design tokens: `primary`, `secondary`, `success`, `warning`, and `danger`, each with a different color value.

Is there anything else you would like to know?