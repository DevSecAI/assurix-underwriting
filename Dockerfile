# ASR-IAC-005: runs as root.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY out/ ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "Assurix.dll"]
