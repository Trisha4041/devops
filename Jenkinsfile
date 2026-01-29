pipeline {
    agent any

    environment {
        // Optional: ensures dotnet uses a writable home
        DOTNET_CLI_HOME = "${WORKSPACE}/.dotnet"
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release --no-build'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish --configuration Release --no-build -o publish'
            }
        }
    }

    post {
        success {
            echo '✅ Build, test, and publish successful!'
        }
        failure {
            echo '❌ Pipeline failed'
        }
    }
}
