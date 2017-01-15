pipeline {
    agent { docker 'microsoft/dotnet:latest'}
    
    stages{
        stage('Build binaries'){
            steps{
                sh 'cd src && dotnet restore'
                sh 'cd src && dotnet publish src/MissionControl.ServiceRadar.Host/project.json -c Release -r ubuntu.14.04-x64 -o ./publish'
                stash includes: 'src/publish/**', name: 'prod_bins' 
            }
        }
    }
}