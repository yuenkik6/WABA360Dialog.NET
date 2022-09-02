FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 431

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WABA360Dialog.NET.Example/WABA360Dialog.NET.Example.csproj", "WABA360Dialog.NET.Example/"]
COPY ["WABA360Dialog.NET/WABA360Dialog.NET.csproj", "WABA360Dialog.NET/"]
RUN dotnet restore "WABA360Dialog.NET.Example/WABA360Dialog.NET.Example.csproj"
COPY . .
WORKDIR "/src/WABA360Dialog.NET.Example"
RUN dotnet build "WABA360Dialog.NET.Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WABA360Dialog.NET.Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WABA360Dialog.NET.Example.dll"]
