FROM microsoft/dotnet:runtime

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY src/xcarpaccio/bin/Debug/netcoreapp1.0 .
ENTRYPOINT ["dotnet", "xcarpaccio.dll"]

EXPOSE 5000