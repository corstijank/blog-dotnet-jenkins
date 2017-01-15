FROM microsoft/dotnet:runtime
COPY publish /app
WORKDIR /app
RUN ["chmod", "744", "./blog-dotnet-jenkins"] 
ENTRYPOINT ["./blog-dotnet-jenkins"]