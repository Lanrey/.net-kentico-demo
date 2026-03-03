# Contract Pitch: B2B Lead-Gen Portal Starter

## Objective
Build a production-oriented starter for Xperience by Kentico 31.1.1 on ASP.NET Core .NET 10 using MVC website delivery, with targeted Vue 3 and Blazor components to demonstrate modern frontend orchestration without going headless.

## Why this wins
- Delivers a working non-headless website-channel pattern aligned with Kentico MVC projects.
- Shows senior architecture decisions: feature boundaries, integration seams, testability, and operational endpoints.
- Balances speed with extensibility: pages and widgets for marketers, API-backed interactive modules for campaign teams.

## Scope (MVP)
- Landing page and resource page templates.
- Lead scoring service and lead submission integration boundary.
- Vue campaign widget for pre-qualification.
- Blazor lead workbench component for richer sales tooling.
- Health endpoint and basic test coverage.

## Technical positioning
- Primary rendering: Razor Pages + MVC style composition.
- Interactive islands: Vue 3 for campaign UX; Blazor for complex server-backed interactions.
- Backend architecture: Web, Features, Integrations projects with DI-driven contracts.

## 2-Week Delivery Outline
- Days 1-3: solution setup, content model, page skeletons, routing.
- Days 4-6: widgets/components, lead scoring, submission workflow.
- Days 7-9: integration hardening, validation, error handling, telemetry hooks.
- Days 10-12: test pass, optimization, demo script and handover.
