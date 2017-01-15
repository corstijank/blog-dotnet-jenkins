pipeline {
    agent { docker 'microsoft/dotnet:latest'}
    
    stages{
        stage('Build binaries'){
            steps{
                sh 'dotnet restore'
                sh 'dotnet publish project.json -c Release -r ubuntu.14.04-x64 -o ./publish'
                stash includes: 'publish/**', name: 'prod_bins' 
            }
        }
    }
}