FROM microsoft/dotnet:runtime
COPY publish /app
WORKDIR /app
RUN ["chmod", "744", "./TodoApi"] 
ENTRYPOINT ["./TodoApi"]