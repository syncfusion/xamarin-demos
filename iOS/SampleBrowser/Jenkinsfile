 node('xammacUI') 
 { 
 timestamps{
    stage ('Checkout')
    {
		try
		{	
			//checkout the xamarinios-samplebrowser Source	
			checkout([$class: 'GitSCM', branches: [[name: '*/$gitlabSourceBranch']], doGenerateSubmoduleConfigurations: false, extensions: [[$class: 'RelativeTargetDirectory', relativeTargetDir: 'xamarinios-samplebrowser']], submoduleCfg: [], userRemoteConfigs: [[credentialsId: env.gitlabCredentialId, url: 'https://gitlab.syncfusion.com/essential-studio/xamarinios-samplebrowser.git']]])
	  
			//checkout the essentialstudio-common Source
			checkout([$class: 'GitSCM', branches: [[name: '*/development']], doGenerateSubmoduleConfigurations: false, extensions: [[$class: 'RelativeTargetDirectory', relativeTargetDir: 'essentialstudio-common']], submoduleCfg: [], userRemoteConfigs: [[credentialsId: env.gitlabCredentialId, url: 'https://gitlab.syncfusion.com/essential-studio/essentialstudio-common.git']]])
		}
		catch(Exception e)
		{
		    echo "Exception in 'Checkout' stage \r\n"+ e
			currentBuild.result = 'FAILURE'
		} 
	}
	
if(currentBuild.result != 'FAILURE')
{ 
	stage ('Mac Build Source')
	{
		try
		{				 
			gitlabCommitStatus("Build")
			{
				 sh('export PATH=/Library/Frameworks/Mono.framework/Versions/Current/bin/:$PATH && sh xamarinios-samplebrowser/build/build.sh -s '+env.WORKSPACE+"/xamarinios-samplebrowser/build/build.cake -t Build --nugetserverurl " +env.nugetserverurls+" --studioversion "+env.studio_version)
			}
			
			def files = findFiles(glob: '**/cireports/errorlogs/*.txt')

			if(files.size() > 0)
			{
			   currentBuild.result = 'FAILURE'
			}
		}
		catch(Exception e) 
		{
		   echo "Exception in 'Build' stage \r\n"+ e
		   currentBuild.result	= 'FAILURE'
		}
    }
    
}

if(currentBuild.result != 'FAILURE' && env.publishBranch.contains(gitlabSourceBranch))
{ 
	stage ('Publish')
	{
		try
		{	
	        //method to get release notes content
	        def branchCommit = 'https://gitlab.syncfusion.com/api/v4/projects/809/merge_requests/'+env.MergeRequestId+'/commits'
	        def branchCommitDetails = sh (script:'curl -s --request GET --header PRIVATE-TOKEN:'+env.BuildAutomation_PrivateToken+' '+branchCommit,returnStdout: true);
	        echo branchCommitDetails
	        def splitCommitDetails=branchCommitDetails.toString().split('\n')
	        def splitMessageDetails = splitCommitDetails[0].split('"message":')
	        def releaseNotesContent=""; 
		    for(int k=1; k<splitMessageDetails.size();k++)
		    {
			    def commitDetails = splitMessageDetails[k].split('"author_email":')
			    for(int j=1; j<commitDetails.size(); j++)
			    {			
				     releaseNotesContent+=commitDetails[0].replace(',"author_name":',' - ').replace('\\n','').replace('",','"')+"\r\n";
			    }
		    }
		    if (releaseNotesContent) 
		    {  
		        writeFile file: env.WORKSPACE+"/cireports/releasenotes/releasenotes.txt", text: releaseNotesContent
		    }
		    else  
		    {
		        writeFile file: env.WORKSPACE+"/cireports/releasenotes/releasenotes.txt", text: "No commit details found for this job."
		    }
	           
	        
			gitlabCommitStatus("Publish")
			{
				 sh('export PATH=/Library/Frameworks/Mono.framework/Versions/Current/bin/:$PATH && sh xamarinios-samplebrowser/build/build.sh -s '+env.WORKSPACE+"/xamarinios-samplebrowser/build/build.cake -t Publish --nugetserverurl "+env.nugetserverurls+" --apitoken  " +env.Hockey_apitoken)
			}
		}
		catch(Exception e) 
		{
		  echo "Exception in 'Publish' stage \r\n"+ e
		  currentBuild.result	= 'FAILURE'
		}
    }
    
}

stage ('Delete Workspace')
	{
		
		// Archiving artifacts when the folder was not empty
		
		def files = findFiles(glob: '**/cireports/**/*.*')      
		
		if(files.size() > 0) 		
		{ 		
			archiveArtifacts artifacts: 'cireports/', excludes: null 		
		}
		
		step([$class: 'WsCleanup']) 
	}
} 
}