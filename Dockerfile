
# Stage: Se compila la app
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

# Se restauran las dependencias
COPY *.csproj ./
RUN dotnet restore

# Compilacion del app
COPY . .
RUN dotnet publish -c Release -o out

# Stage: Se lanza el app
FROM mcr.microsoft.com/dotnet/sdk:6.0 as prod
WORKDIR /app

# Se copia el compilado
COPY --from=build /app/out ./

# Se establecen las env
ENV SERVER=${SERVER}
ENV BD=${BD}
ENV USERBD=${USERBD}
ENV PASSWORD=${PASSWORD}

# Se levanta el app
ENTRYPOINT ["dotnet", "F1Console.dll"]