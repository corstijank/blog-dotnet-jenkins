FROM microsoft/dotnet:1.1.0-runtime
# Add our application
COPY publish /app
WORKDIR /app
# The network port of our todo API
EXPOSE 5000
# Set docker environment
ENV ASPNETCORE_ENVIRONMENT=docker
# Mark as executable, and set the app as entrypoint
RUN ["chmod", "744", "./TodoApi"] 
ENTRYPOINT ["./TodoApi"]