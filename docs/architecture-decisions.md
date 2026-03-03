# Architecture Decisions

## ADR-001: Layered modular monolith
- Web project handles endpoints, pages, UI composition.
- Features project contains domain use-cases (lead scoring).
- Integrations project isolates external system calls (CRM/marketing).

## ADR-002: Non-headless delivery first
- Keep Kentico MVC website channel as delivery model.
- Use APIs internally for interaction modules, not as a full headless contract.

## ADR-003: Mixed frontend strategy by intent
- Vue 3 for lightweight campaign modules embedded in Razor pages.
- Blazor components for stateful server-connected tools.
- Avoid full SPA complexity for primary website pages.

## ADR-004: Operational readiness baseline
- Add health endpoint for deployment checks.
- Keep testing baseline in place to support CI quality gates.
