FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./PriorityQueueDemo/PriorityQueueDemo.csproj", ""]
RUN dotnet restore "PriorityQueueDemo.csproj"
COPY ./PriorityQueueDemo/ .
WORKDIR "/src/"
RUN dotnet build "PriorityQueueDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PriorityQueueDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

CMD ["dotnet", "PriorityQueueDemo.dll"]