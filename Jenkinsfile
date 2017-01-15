pipeline {
    // No overall agent, rather, set up agent per stage; gives us delscoupled stages
    agent none
    stages{
        stage('Build binaries'){
            // Run this stage in a docker container with the dotnet sdk
            agent { docker 'microsoft/dotnet:latest'}
            steps{
                sh 'dotnet restore'
                sh 'dotnet publish project.json -c Release -r ubuntu.14.04-x64 -o ./publish'
                stash includes: 'git stpublish/**', name: 'prod_bins' 
            }
        }
        stage('Create docker image'){
            // Run this stage any agent with a 'hasDocker' label
            agent { label 'hasDocker' }
            steps{
                // Unstash the binaries from the previous tage
                unstash 'prod_bins'
                sh 'docker build -t "blog-dotnet-jenkins:1.0" .'
            }
        }
    }
}