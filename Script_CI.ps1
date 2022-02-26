Write-Host "Script de CI pour le projet du Grand Restaurant"
Write-Host "Pensez a préciser dans le script le bon repertoire git local"

cd C:\Users\allen\Documents\Github\LeGrandRestaurant

git checkout master
git fetch
git branch 

try {
    $branch = Read-Host -Prompt "Merci de preciser la branche git que vous souhaitez integrer"
    if($branch -ne "master"){
        git checkout $branch
    }
    git branch
    
}catch{
    
    throw "Branche invalide"
}

Write-Host "Tentative de Build du projet"
$isPassed = $false
try{
    dotnet build LeGrandRestaurant.sln > log.txt 
    if((Select-String -Path 'log.txt' -Pattern "CHEC") -eq $null ){$isPassed = $true}else{Write-Host "Le build a crash, le projet ne compile pas"}
}catch{
    throw "Erreur lors du lancement du build"
}


if($isPassed){
    Write-Host "Le build est bien passe, lancement des tests"
    $isPassed = $false
    try{
        dotnet test .\LeGrandRestaurant\LeGrandRestaurant.test.csproj > logTest.txt
        if((Select-String -Path 'logTest.txt' -Pattern "error") -eq $null ){$isPassed = $true}else{Write-Host "Vos tests ne sont pas au vert" }
    }catch{
        throw "Une erreur s est produite lors du lancement des test"
    }

}

if($isPassed){
    Write-Host "Felicitation tout tes tests sont au vert"
}
