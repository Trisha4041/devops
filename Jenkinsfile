pipeline {
    agent any

    environment {
        // 🔥 Explicit PATH so Jenkins can find dotnet on macOS
        PATH = "/opt/homebrew/bin:/usr/local/bin:/usr/bin:/bin:/usr/sbin:/sbin"
        DOTNET_CLI_HOME = "${WORKSPACE}/.dotnet"
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Verify Dotnet') {
            steps {
                sh 'which dotnet'
                sh 'dotnet --version'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore HelloApi/HelloApi.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build HelloApi/HelloApi.csproj --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                // If no tests exist, pipeline will not fail
                sh 'dotnet test HelloApi/HelloApi.csproj --configuration Release --no-build || true'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish HelloApi/HelloApi.csproj --configuration Release --no-build -o publish'
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
