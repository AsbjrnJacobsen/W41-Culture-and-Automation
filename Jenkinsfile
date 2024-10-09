pipeline {
    agent any

    stages {                
        stage('Build') {
            steps {
                // Build the project (example for a Maven project)
                dotnetBuild configuration: 'Debug', project: 'LoggingAPI', sdk: 'sdk 8.0'
            }
        }

        stage('Test') {
            steps {
                // Run unit tests (example for a Maven project)
                dotnetBuild configuration: 'Debug', project: 'LoggingAPI', sdk: 'sdk 8.0'
            }
        }

        stage('Deploy') {
            steps {
                //Login to docker
                withCredentials([usernamePassword(credentialsId: 'dockerhub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]){
                    // Build dockerfile into image.
                    sh "docker build -t loggingapiimage -f LoggingAPI/Dockerfile ."
                    sh 'docker login -u $USERNAME -p $PASSWORD'
                    // push dockerimage to dockerhub
                    sh "docker push loggingapiimage:latest"
                }
            }
        }
    }
}
