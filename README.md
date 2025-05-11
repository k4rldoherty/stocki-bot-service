# Stocki - Discord Bot for Stock & News Insights

A Discord bot built with Discord.NET that provides real-time stock prices, financial news, and future subscription/chat features for traders and investors.

## Overview

Stocki integrates with external financial APIs to deliver actionable insights via Discord slash commands. Designed for traders, students, or hobbyists interested in market data.
Key Features

## Slash Commands:

- /stock-price <ticker>: Fetch real-time stock prices (e.g., /stock price AAPL).
- /news <ticker>: Retrieve financial news articles (e.g., /news "AAPL").
- /subscribe <ticker>: (Future) Set price alerts for stocks (under development).
- /unsubscribe <ticker>: (Future) Set price alerts for stocks (under development).
- /chat <query>: (Future) AI-powered market analysis (planned).
- Modular Design: Clean separation of API integrations, Discord logic, and business rules.
- Scalable: Built for future integration with databases (e.g., PostgreSQL) for user subscriptions.

## Tech Stack

- Language: C#
- Framework: Discord.NET (latest version)
- APIs Used:
  -- Alpha Vantage (stock data)
  -- Finnhub (stock data)
  -- OpenAI API (planned for /chat feature)
- Tools:
  -- .NET 6/7 SDK
  -- Docker (optional for deployment)

## Installation & Setup

### Requirements

- Discord bot token (create one via Discord Developer Portal).
- API keys for external services.
- .NET9 SDK installed.

## Steps

- Clone the repo:
- git clone https://github.com/yourusername/stocki.git
- Install dependencies:
- dotnet restore
- Configure environment variables:
- DISCORD_TOKEN=your_discord_bot_token
- ALPHA_VANTAGE_API_KEY=your_alphavantage_key
- NEWSAPI_KEY=your_newsapi_key
- Build and run:
- dotnet build
- dotnet run
