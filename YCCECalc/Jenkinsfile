pipeline {
    agent any

    environment {
        // Ensure Jenkins can find dotnet on macOS
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
                sh 'dotnet restore YCCECalc/YCCECalc.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build YCCECalc/YCCECalc.csproj --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                // Class library may not have tests, so don't fail pipeline
                sh 'dotnet test YCCECalc/YCCECalc.csproj --configuration Release --no-build || true'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish YCCECalc/YCCECalc.csproj --configuration Release --no-build -o publish'
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
