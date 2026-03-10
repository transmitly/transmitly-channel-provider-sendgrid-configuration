# Transmitly.ChannelProvider.SendGrid.Configuration

Shared SendGrid configuration and extension contracts for Transmitly channel providers.

## Should you use this package?

Use this package if you are building or extending a SendGrid provider for the Transmitly ecosystem and need the shared SendGrid option types and email extension contracts.

If you are building an application and just want to send email through SendGrid, use [`Transmitly.ChannelProvider.SendGrid`](https://github.com/transmitly/transmitly-channel-provider-sendgrid) instead.

## What This Package Provides

- `SendGridOptions` with `ApiKey`, `Host`, `Version`, `HttpErrorAsException`, request-header support, authentication settings, reliability settings, and provider user-agent support.
- `ChannelProviders.SendGrid(providerId)` for resolving a Transmitly channel-provider id.
- `email.SendGrid()` for SendGrid-specific email settings.
- Delivery-report interfaces and builder extensions for registering concrete SendGrid delivery-report adaptors.
- `TemplateId` support for provider-managed SendGrid templates.

## Related Packages

- [Transmitly](https://github.com/transmitly/transmitly)
- [Transmitly.ChannelProvider.SendGrid](https://github.com/transmitly/transmitly-channel-provider-sendgrid)
- [Transmitly.ChannelProvider.SendGrid.Sdk](https://github.com/transmitly/transmitly-channel-provider-sendgrid-sdk)

---
_Copyright (c) Code Impressions, LLC. This open-source project is sponsored and maintained by Code Impressions and is licensed under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html)._
