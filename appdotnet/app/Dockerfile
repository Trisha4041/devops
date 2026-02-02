FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /app

# copy everything
COPY . .

# build + publish
RUN dotnet publish -c Release -o out

# run the app
ENTRYPOINT ["dotnet", "out/app.dll"]
