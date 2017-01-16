pipeline {
    // No overall agent, rather, set up agent per stage; gives us decoupled stages
    agent none
    stages{
        stage('Build binaries'){
            // Run this stage in a docker container with the dotnet sdk
            agent { docker 'microsoft/dotnet:latest'}
            steps{
                git url: 'https://github.com/corstijank/blog-dotnet-jenkins.git'
                sh 'dotnet restore'
                sh 'dotnet publish project.json -c Release -r ubuntu.14.04-x64 -o ./publish'
                stash includes: 'publish/**', name: 'prod_bins' 
            }
        }
        stage('Create docker image'){
            // Run this stage any agent with a 'hasDocker' label
            agent { label 'hasDocker' }
            environment {
                DOCKER_ID = credentials('docker-id')
            }
            steps{
                // Unstash the binaries from the previous tage
                unstash 'prod_bins'
                sh "docker build -t corstijank/blog-dotnet-jenkins:1.0-${env.BUILD_NUMBER} ."
                sh "docker tag blog-dotnet-jenkins:1.0-${env.BUILD_NUMBER} corstijank/blog-dotnet-jenkins:latest"
                sh "docker login -u ${DOCKER_ID_USR} -p ${DOCKER_ID_PSW}"
                sh "docker push blog-dotnet-jenkins:1.0-${env.BUILD_NUMBER}"
                sh "docker push corstijank/blog-dotnet-jenkins:latest"
            }
        }
    }
}