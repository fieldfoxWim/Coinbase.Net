# Coinbase.Net

[![.NET](https://github.com/fieldfoxWim/Coinbase.Net/actions/workflows/dotnet.yml/badge.svg)](https://github.com/fieldfoxWim/Gateio.Net/actions/workflows/dotnet.yml)

Coinbase.Net is a .Net wrapper for the Coinbase.io API

# Readme

## Deploy to feedzio

```
cd Coinbase.Net
dotnet publish -c Release
dotnet nuget push --source https://f.feedz.io/fieldfox/fieldfox/nuget/index.json --api-key T-pRipwTfRT51wJXgH4iVHDNCySFxGt2jhs ./bin/Release/Coinbase.Net.1.1.0.nupkg```

Replace `T-xxx` with the feedzio token.

## Credits

This wrapper was built using [CryptoExchange.Net](https://github.com/JKorf/CryptoExchange.Net/) by @JKorf
and used https://github.com/JKorf/Binance.Net as the primary example.
