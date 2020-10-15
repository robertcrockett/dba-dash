﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBAChecks.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DBAChecks.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
        ///WITH T
        ///AS (SELECT j.job_id,
        ///           j.name,
        ///           MAX(   CASE
        ///                      WHEN jh.step_id = 0
        ///                      AND  jh.run_status &lt;&gt; 1 THEN
        ///                          dt.RunDateTime
        ///                      ELSE
        ///                          NULL
        ///                  END
        ///              ) LastFail,
        ///           MAX(   CASE
        ///                      WHEN jh.step_id = 0
        ///                      AND  jh.run_status = 1 THEN
        ///                       [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLAgentJobs {
            get {
                return ResourceManager.GetString("SQLAgentJobs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT id,
        ///	name,
        ///	message_id,
        ///	severity,
        ///	enabled,
        ///	delay_between_responses,
        ///	msdb.dbo.AGENT_DATETIME(NULLIF(last_occurrence_date,0),last_occurrence_time) last_occurrence,
        ///	msdb.dbo.AGENT_DATETIME(NULLIF(last_response_date,0),last_response_time) last_response,
        ///	notification_message,
        ///	include_event_description,
        ///	database_name,
        ///	event_description_keyword,
        ///	occurrence_count,
        ///	msdb.dbo.AGENT_DATETIME(NULLIF(count_reset_date,0),count_reset_time) as count_reset,
        ///	job_id,
        ///	has_notification,
        ///	categ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLAlerts {
            get {
                return ResourceManager.GetString("SQLAlerts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT start_time,
        ///       end_time,
        ///       elastic_pool_name,
        ///       avg_cpu_percent,
        ///       avg_data_io_percent,
        ///       avg_log_write_percent,
        ///       avg_storage_percent,
        ///       max_worker_percent,
        ///       max_session_percent,
        ///       elastic_pool_dtu_limit,
        ///       elastic_pool_storage_limit_mb,
        ///       avg_allocated_storage_percent
        ///FROM sys.elastic_pool_resource_stats 
        ///WHERE start_time&gt;=@Date.
        /// </summary>
        internal static string SQLAzureDBElasticPoolResourceStats {
            get {
                return ResourceManager.GetString("SQLAzureDBElasticPoolResourceStats", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT end_time,
        ///       avg_cpu_percent,
        ///       avg_data_io_percent,
        ///       avg_log_write_percent,
        ///       avg_memory_usage_percent,
        ///       xtp_storage_percent,
        ///       max_worker_percent,
        ///       max_session_percent,
        ///       dtu_limit,
        ///       avg_instance_cpu_percent,
        ///       avg_instance_memory_percent,
        ///       cpu_limit,
        ///       replica_role
        ///FROM sys.dm_db_resource_stats
        ///WHERE end_time &gt;= @Date.
        /// </summary>
        internal static string SQLAzureDBResourceStats {
            get {
                return ResourceManager.GetString("SQLAzureDBResourceStats", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT edition,
        ///       service_objective,
        ///       elastic_pool_name 
        ///FROM sys.database_service_objectives
        ///WHERE database_id = DB_ID().
        /// </summary>
        internal static string SQLAzureDBServiceObjectives {
            get {
                return ResourceManager.GetString("SQLAzureDBServiceObjectives", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select database_name,type, MAX(backup_start_date) LastBackup
        ///from msdb.dbo.backupset
        ///where server_name=@@SERVERNAME
        ///AND backup_finish_date&gt;=DATEADD(d,-10,GETUTCDATE())
        ///group by database_name, type.
        /// </summary>
        internal static string SQLBackups {
            get {
                return ResourceManager.GetString("SQLBackups", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @MinWaitTimeMs INT 
        ///SET @MinWaitTimeMs= 1000
        ///
        ///DECLARE @DBIDTable NVARCHAR(MAX)
        ///DECLARE @SQL NVARCHAR(MAX)
        ///SELECT @DBIDTable= CASE WHEN COLUMNPROPERTY(OBJECT_ID(&apos;sys.dm_exec_sessions&apos;),&apos;database_id&apos;,&apos;ColumnId&apos;) IS NULL THEN &apos;R.&apos; ELSE &apos;S.&apos; END 
        ///SET @SQL =N&apos;
        ///	DECLARE @UTCOffset INT 
        ///	SELECT @UTCOffset= DATEDIFF(mi,GETDATE(),GETUTCDATE());
        ///	WITH R AS (
        ///		SELECT GETUTCDATE() SnapshotDateUTC,
        ///			@UTCOffset AS UTCOffset,
        ///			S.session_id,
        ///			ISNULL(R.blocking_session_id,0) AS blocking_session_i [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLBlockingSnapshot {
            get {
                return ResourceManager.GetString("SQLBlockingSnapshot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
        ///DECLARE @Corruption TABLE(
        ///		SourceTable TINYINT,
        ///		database_id INT NOT NULL,
        ///		last_update_date DATETIME NOT NULL
        ///)
        ///IF OBJECT_ID(&apos;msdb.dbo.suspect_pages&apos;) IS NOT NULL
        ///BEGIN
        ///	INSERT INTO @Corruption(SourceTable,database_id,last_update_date)
        ///	SELECT CAST(1 AS TINYINT) AS SourceTable,
        ///		   database_id,
        ///		   MAX(last_update_date) last_update_date
        ///	FROM msdb.dbo.suspect_pages
        ///	GROUP BY database_id
        ///END
        ///IF OBJECT_ID(&apos;msdb.sys.dm_db_mirroring_auto_pag [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLCorruption {
            get {
                return ResourceManager.GetString("SQLCorruption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF OBJECT_ID(&apos;sys.dm_db_resource_stats&apos;) IS NOT NULL
        ///BEGIN
        ///	SELECT TOP(@TOP) end_time AS EventTime,
        ///		CAST(avg_cpu_percent AS INT),
        ///		100-CAST(avg_cpu_percent AS INT) AS SystemIdle
        ///	FROM sys.dm_db_resource_stats
        ///END
        ///ELSE
        ///BEGIN
        ///	DECLARE @ts_now bigint 
        ///	SELECT @ts_now= cpu_ticks/(cpu_ticks/ms_ticks) 
        ///	FROM sys.dm_os_sys_info; 
        /// 
        ///	SELECT TOP(@TOP) DATEADD(ms, -1 * (@ts_now - [timestamp]), GETUTCDATE()) AS [EventTime],
        ///					SQLProcessUtilization AS [SQLProcessCPU], 
        ///				   SystemIdle AS [SystemI [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLCPU {
            get {
                return ResourceManager.GetString("SQLCPU", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SET NOCOUNT ON
        ///
        ///DECLARE @DBName SYSNAME
        ///DECLARE @SQL NVARCHAR(MAX)
        ///CREATE TABLE #permissions
        ///(
        ///	database_id INT NOT NULL,
        ///    [class] TINYINT NOT NULL,
        ///    [class_desc] NVARCHAR(60) NULL,
        ///    [major_id] INT NOT NULL,
        ///    [minor_id] INT NOT NULL,
        ///    [grantee_principal_id] INT NOT NULL,
        ///    [grantor_principal_id] INT NOT NULL,
        ///    [type] CHAR(4) NOT NULL,
        ///    [permission_name] NVARCHAR(128) NULL,
        ///    [state] CHAR(1) NOT NULL,
        ///    [state_desc] NVARCHAR(60) NULL,
        ///    [schema_name] NVARCHAR(128 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDatabasePermissions {
            get {
                return ResourceManager.GetString("SQLDatabasePermissions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SET NOCOUNT ON
        ///DECLARE @EditionID BIGINT
        ///SELECT @EditionID = CAST(SERVERPROPERTY(&apos;EditionID&apos;) as bigint) 
        ///
        ///DECLARE @DBName SYSNAME
        ///DECLARE @SQL NVARCHAR(MAX)
        ///CREATE TABLE #DBPrincipals
        ///(
        ///	database_id INT NOT NULL,
        ///    [name] NVARCHAR(128),
        ///    [principal_id] INT,
        ///    [type] CHAR(1),
        ///    [type_desc] NVARCHAR(60),
        ///    [default_schema_name] NVARCHAR(128),
        ///    [create_date] DATETIME,
        ///    [modify_date] DATETIME,
        ///    [owning_principal_id] INT,
        ///    [sid] VARBINARY(85),
        ///    [is_fixed_role] BIT,
        ///  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDatabasePrincipals {
            get {
                return ResourceManager.GetString("SQLDatabasePrincipals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SET NOCOUNT ON
        ///
        ///DECLARE @DBName SYSNAME
        ///DECLARE @SQL NVARCHAR(MAX)
        ///CREATE TABLE #DBRoleMembers
        ///(
        ///	database_id INT NOT NULL,
        ///    [role_principal_id] INT NOT NULL,
        ///	[member_principal_id] INT NOT NULL
        ///);
        ///
        ///
        ///
        ///DECLARE DBs CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
        ///SELECT name
        ///FROM sys.databases
        ///WHERE state  = 0
        ///AND HAS_DBACCESS(name)=1
        ///
        ///OPEN DBs
        ///FETCH NEXT FROM DBs INTO @DBName
        ///
        ///WHILE @@FETCH_STATUS = 0
        ///BEGIN
        ///
        ///	SET @SQL =  N&apos;USE &apos; + QUOTENAME(@DBName)  + &apos; 
        ///SELECT DB_ID(), 
        ///	   	           [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDatabaseRoleMembers {
            get {
                return ResourceManager.GetString("SQLDatabaseRoleMembers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE #sysdb(
        ///	[name] [sysname] NOT NULL,
        ///	[database_id] [int] NOT NULL,
        ///	[source_database_id] [int] NULL,
        ///	[owner_sid] [varbinary](85) NULL,
        ///	[create_date] [datetime] NOT NULL,
        ///	[compatibility_level] [tinyint] NOT NULL,
        ///	[collation_name] [sysname] NULL,
        ///	[user_access] [tinyint] NULL,
        ///	[is_read_only] [bit] NULL,
        ///	[is_auto_close_on] [bit] NOT NULL,
        ///	[is_auto_shrink_on] [bit] NULL,
        ///	[state] [tinyint] NULL,
        ///	[is_in_standby] [bit] NULL,
        ///	[is_cleanly_shutdown] [bit] NULL,
        ///	[is_supplemental_ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDatabases {
            get {
                return ResourceManager.GetString("SQLDatabases", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF OBJECT_ID(&apos;sys.dm_hadr_database_replica_states&apos;) IS NOT NULL
        ///BEGIN
        ///    SELECT database_id,
        ///           group_database_id,
        ///           is_primary_replica,
        ///           synchronization_state,
        ///           synchronization_health,
        ///           is_suspended,
        ///           suspend_reason
        ///    FROM sys.dm_hadr_database_replica_states
        ///    WHERE is_local = 1;
        ///END;.
        /// </summary>
        internal static string SQLDatabasesHADR {
            get {
                return ResourceManager.GetString("SQLDatabasesHADR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @DBName SYSNAME
        ///DECLARE @SQL NVARCHAR(MAX)
        ///CREATE TABLE #DBConfig( 
        ///	database_id INT NOT NULL,
        ///	configuration_id INT NOT NULL,
        ///	name NVARCHAR(60) NOT NULL,
        ///	value NVARCHAR(128) NULL,
        ///	value_for_secondary NVARCHAR(128) NULL,
        ///	PRIMARY KEY (database_id,configuration_id)
        ///)
        ///
        ///IF OBJECT_ID(&apos;sys.database_scoped_configurations&apos;) IS NOT NULL
        ///BEGIN
        ///	DECLARE DBs CURSOR FAST_FORWARD READ_ONLY FOR
        ///	SELECT name
        ///	FROM sys.databases
        ///	WHERE state  = 0
        ///	AND DATABASEPROPERTYEX(name, &apos;Updateability&apos;) =  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDBConfig {
            get {
                return ResourceManager.GetString("SQLDBConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @DBName SYSNAME
        ///DECLARE @SQL NVARCHAR(MAX)
        ///CREATE TABLE #FileList ( 
        ///database_id INT,
        ///file_id INT,
        ///data_space_id INT,
        ///name SYSNAME,
        ///filegroup_name SYSNAME NULL,
        ///physical_name nvarchar(260),
        ///type TINYINT,
        ///size bigint,
        ///space_used bigint,
        ///max_size bigint,
        ///growth bigint,
        ///is_percent_growth bit,
        ///is_read_only BIT,
        ///state TINYINT
        ///)
        ///
        ///DECLARE DBs CURSOR FAST_FORWARD LOCAL FOR
        ///SELECT name
        ///FROM sys.databases
        ///WHERE state  = 0
        ///AND DATABASEPROPERTYEX(name, &apos;Updateability&apos;) = &apos;READ_WRITE&apos;
        ///
        ///O [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDBFiles {
            get {
                return ResourceManager.GetString("SQLDBFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @DBName SYSNAME
        ///DECLARE @SQL NVARCHAR(MAX)
        ///CREATE TABLE #autotune( 
        ///	database_id INT NOT NULL,
        ///	[name] nvarchar(128), 
        ///	[desired_state_desc] nvarchar(60), 
        ///	[actual_state_desc] nvarchar(60), 
        ///	[reason_desc] nvarchar(60) 
        ///	PRIMARY KEY (database_id,name)
        ///)
        ///
        ///IF OBJECT_ID(&apos;sys.database_automatic_tuning_options&apos;) IS NOT NULL
        ///BEGIN
        ///	DECLARE DBs CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
        ///	SELECT name
        ///	FROM sys.databases
        ///	WHERE state  = 0
        ///	AND DATABASEPROPERTYEX(name, &apos;Updateability&apos;) = &apos;READ_ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLDBTuningOptions {
            get {
                return ResourceManager.GetString("SQLDBTuningOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF OBJECT_ID(&apos;sys.dm_os_volume_stats&apos;) IS NOT NULL
        ///BEGIN
        ///	SELECT DISTINCT dovs.volume_mount_point AS Name,
        ///		dovs.total_bytes as Capacity,
        ///		dovs.available_bytes as FreeSpace,
        ///		dovs.logical_volume_name as Label
        ///	FROM sys.master_files mf
        ///	CROSS APPLY sys.dm_os_volume_stats(mf.database_id, mf.FILE_ID) dovs
        ///END.
        /// </summary>
        internal static string SQLDrives {
            get {
                return ResourceManager.GetString("SQLDrives", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF SERVERPROPERTY(&apos;EditionID&apos;)=1674378470
        ///BEGIN
        ///	SELECT GETUTCDATE() AS SnapshotDate,
        ///		   [database_id],
        ///		   [file_id],
        ///		   [sample_ms],
        ///		   [num_of_reads],
        ///		   [num_of_bytes_read],
        ///		   [io_stall_read_ms],
        ///		   [num_of_writes],
        ///		   [num_of_bytes_written],
        ///		   [io_stall_write_ms],
        ///		   [io_stall],
        ///		   [size_on_disk_bytes]
        ///	FROM sys.dm_io_virtual_file_stats(DB_ID(), NULL) vfs;
        ///END
        ///ELSE
        ///BEGIN
        ///	SELECT GETUTCDATE() AS SnapshotDate,
        ///		   [database_id],
        ///		   [file_id],
        ///		   [sample_ms [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLIOStats {
            get {
                return ResourceManager.GetString("SQLIOStats", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @SQL NVARCHAR(MAX)
        ///DECLARE @DBName SYSNAME
        ///DECLARE @DBID INT
        ///IF DATABASEPROPERTYEX(DB_NAME(),&apos;LastGoodCheckDbTime&apos;) IS NULL
        ///BEGIN
        ///	DECLARE DBs CURSOR FAST_FORWARD READ_ONLY FOR
        ///	SELECT name,database_id
        ///	FROM sys.databases
        ///	WHERE state  = 0
        ///	AND DATABASEPROPERTYEX(name, &apos;Updateability&apos;) = &apos;READ_WRITE&apos;
        ///
        ///	DECLARE @dbinfo TABLE
        ///			( ParentObject VARCHAR(255) ,
        ///			  Object VARCHAR(255) ,
        ///			  Field VARCHAR(255) ,
        ///			  Value VARCHAR(255) 
        ///			);
        ///	DECLARE @LastGoodDBCC TABLE(
        ///		database_id [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLLastGoodCheckDB {
            get {
                return ResourceManager.GetString("SQLLastGoodCheckDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH t
        ///AS (SELECT rsh.destination_database_name AS database_name,
        ///           rsh.restore_date,
        ///           bs.backup_start_date,
        ///           bmf.physical_device_name AS last_file,
        ///           ROW_NUMBER() OVER (PARTITION BY rsh.destination_database_name
        ///                              ORDER BY rsh.restore_date DESC
        ///                             ) rnum
        ///    FROM msdb.dbo.restorehistory rsh
        ///        INNER JOIN msdb.dbo.backupset bs ON rsh.backup_set_id = bs.backup_set_id
        ///        INNER JOIN msdb.dbo.restoref [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLLogRestores {
            get {
                return ResourceManager.GetString("SQLLogRestores", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @SQL NVARCHAR(MAX)
        ///DECLARE @IsAzure BIT
        ///SELECT @IsAzure = CASE WHEN SERVERPROPERTY(&apos;EditionID&apos;) =1674378470 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END
        ///IF OBJECT_ID(&apos;sys.dm_exec_procedure_stats&apos;) IS NOT NULL
        ///BEGIN
        ///	SET @SQL = N&apos;
        ///			SELECT object_id,
        ///				   database_id,
        ///				   ISNULL(OBJECT_NAME(object_id, database_id),&apos;&apos;&apos;&apos;) object_name,
        ///				   total_worker_time,
        ///				   total_elapsed_time,
        ///				   total_logical_reads,
        ///				   total_logical_writes,
        ///				   total_physical_reads,
        ///				   cache [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLObjectExecutionStats {
            get {
                return ResourceManager.GetString("SQLObjectExecutionStats", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @SQL NVARCHAR(MAX);
        ///
        ///WITH cols AS (
        ///	SELECT &apos;softnuma_configuration&apos; AS col,&apos;INT&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;sql_memory_model&apos; AS col,&apos;INT&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;socket_count&apos; AS col,&apos;INT&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;cores_per_socket&apos; AS col,&apos;INT&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;numa_node_count&apos; AS col,&apos;INT&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;affinity_type&apos; AS col,&apos;INT&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;sqlserver_start_time&apos; AS col,&apos;DATETIME&apos; AS typ
        ///	UNION ALL
        ///	SELECT &apos;os_priority_class&apos; AS col,&apos;IN [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLOSInfo {
            get {
                return ResourceManager.GetString("SQLOSInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT CONVERT(CHAR(16), base_address, 2) base_address_string,
        ///       file_version,
        ///       product_version,
        ///       debug,
        ///       patched,
        ///       prerelease,
        ///       private_build,
        ///       special_build,
        ///       language,
        ///       company,
        ///       description,
        ///       name
        ///FROM sys.dm_os_loaded_modules.
        /// </summary>
        internal static string SQLOSLoadedModules {
            get {
                return ResourceManager.GetString("SQLOSLoadedModules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS(SELECT 1 
        ///			FROM sys.server_event_sessions
        ///			WHERE name = &apos;DBAChecks_1&apos;
        ///			)
        ///BEGIN
        ///	DROP EVENT SESSION DBAChecks_1 ON SERVER;
        ///END
        ///IF EXISTS(SELECT 1 
        ///			FROM sys.server_event_sessions
        ///			WHERE name = &apos;DBAChecks_2&apos;
        ///			)
        ///BEGIN
        ///	DROP EVENT SESSION DBAChecks_2 ON SERVER;
        ///END.
        /// </summary>
        internal static string SQLRemoveEventSessions {
            get {
                return ResourceManager.GetString("SQLRemoveEventSessions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS(SELECT 1 
        ///			FROM sys.database_event_sessions
        ///			WHERE name = &apos;DBAChecks_1&apos;
        ///			)
        ///BEGIN
        ///	DROP EVENT SESSION DBAChecks_1 ON DATABASE;
        ///END
        ///IF EXISTS(SELECT 1 
        ///			FROM sys.database_event_sessions
        ///			WHERE name = &apos;DBAChecks_2&apos;
        ///			)
        ///BEGIN
        ///	DROP EVENT SESSION DBAChecks_2 ON DATABASE;
        ///END.
        /// </summary>
        internal static string SQLRemoveEventSessionsAzure {
            get {
                return ResourceManager.GetString("SQLRemoveEventSessionsAzure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @ProcessorNameString NVARCHAR(512)
        ///DECLARE @SystemManufacturer NVARCHAR(512)
        ///DECLARE @SystemProductName NVARCHAR(512)
        ///DECLARE @IsAgentRunning BIT
        ///DECLARE @InstantFileInitializationEnabled BIT
        ///IF OBJECT_ID(&apos;sys.xp_instance_regread&apos;) IS NOT NULL AND EXISTS(SELECT * FROM fn_my_permissions ( &apos;sys.xp_instance_regread&apos;, &apos;OBJECT&apos; ) WHERE permission_name=&apos;EXECUTE&apos;)
        ///BEGIN  
        ///	EXEC sys.xp_instance_regread N&apos;HKEY_LOCAL_MACHINE&apos;, N&apos;HARDWARE\DESCRIPTION\System\CentralProcessor\0&apos;, N&apos;ProcessorNameString&apos;,@P [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLServerExtraProperties {
            get {
                return ResourceManager.GetString("SQLServerExtraProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT class,
        ///        class_desc,
        ///        major_id,
        ///        minor_id,
        ///        grantee_principal_id,
        ///        grantor_principal_id,
        ///        type,
        ///        permission_name,
        ///        state,
        ///        state_desc
        ///FROM sys.server_permissions.
        /// </summary>
        internal static string SQLServerPermissions {
            get {
                return ResourceManager.GetString("SQLServerPermissions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @SQL NVARCHAR(MAX)
        ///SET @SQL = N&apos;
        ///SELECT name,
        ///       principal_id,
        ///       sid,
        ///       type,
        ///       type_desc,
        ///       is_disabled,
        ///       create_date,
        ///       modify_date,
        ///       default_database_name,
        ///       default_language_name,
        ///       credential_id,
        ///	   &apos; + CASE WHEN COLUMNPROPERTY(OBJECT_ID(&apos;sys.server_principals&apos;),&apos;owning_principal_id&apos;,&apos;ColumnID&apos;) IS NULL THEN &apos;CAST(NULL AS INT) as owning_principal_id,&apos; ELSE &apos;owning_principal_id,&apos; END + &apos;
        ///	   &apos; + CASE WHEN COLUMNPROPERTY(OBJECT_ID( [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLServerPrincipals {
            get {
                return ResourceManager.GetString("SQLServerPrincipals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT CAST(SERVERPROPERTY(&apos;BuildClrVersion&apos;) as nvarchar(128)) as BuildClrVersion ,
        ///CAST(SERVERPROPERTY(&apos;Collation&apos;) as nvarchar(128)) as Collation ,
        ///CAST(SERVERPROPERTY(&apos;CollationID&apos;) as int) as CollationID ,
        ///CAST(SERVERPROPERTY(&apos;ComparisonStyle&apos;) as int) as ComparisonStyle ,
        ///CAST(SERVERPROPERTY(&apos;ComputerNamePhysicalNetBIOS&apos;) as nvarchar(128)) as ComputerNamePhysicalNetBIOS ,
        ///CAST(SERVERPROPERTY(&apos;Edition&apos;) as nvarchar(128)) as Edition ,
        ///CAST(SERVERPROPERTY(&apos;EditionID&apos;) as bigint) as EditionID ,
        ///CAS [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLServerProperties {
            get {
                return ResourceManager.GetString("SQLServerProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT role_principal_id,
        ///       member_principal_id
        ///FROM sys.server_role_members.
        /// </summary>
        internal static string SQLServerRoleMembers {
            get {
                return ResourceManager.GetString("SQLServerRoleMembers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /* Setup - create event sessions if they don&apos;t exist */
        ///DECLARE @SQL NVARCHAR(MAX)
        ///DECLARE @EventSessionTemplate NVARCHAR(MAX) = N&apos;CREATE EVENT SESSION [{EventSessionName}] ON SERVER 
        ///	ADD EVENT sqlserver.rpc_completed(
        ///		ACTION(sqlserver.client_app_name,sqlserver.client_hostname,sqlserver.database_id,sqlserver.username)
        ///		WHERE ([duration]&gt;(&apos; + CAST(@SlowQueryThreshold AS NVARCHAR(MAX)) + &apos;) AND ([sqlserver].[client_app_name]&lt;&gt;N&apos;&apos;DBAChecksXE&apos;&apos; AND [object_name]&lt;&gt;N&apos;&apos;sp_readrequest&apos;&apos;))),
        ///	ADD EVENT sql [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLSlowQueries {
            get {
                return ResourceManager.GetString("SQLSlowQueries", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /* Setup - create event sessions if they don&apos;t exist */
        ///DECLARE @SQL NVARCHAR(MAX)
        ///DECLARE @EventSessionTemplate NVARCHAR(MAX) = N&apos;CREATE EVENT SESSION [{EventSessionName}] ON DATABASE 
        ///	ADD EVENT sqlserver.rpc_completed(
        ///		ACTION(sqlserver.client_app_name,sqlserver.client_hostname,sqlserver.database_id,sqlserver.username)
        ///		WHERE ([duration]&gt;(&apos; + CAST(@SlowQueryThreshold AS NVARCHAR(MAX)) + &apos;) AND ([sqlserver].[client_app_name]&lt;&gt;N&apos;&apos;DBAChecksXE&apos;&apos;))),
        ///	ADD EVENT sqlserver.sql_batch_completed(
        ///		ACTION [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLSlowQueriesAzure {
            get {
                return ResourceManager.GetString("SQLSlowQueriesAzure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS(
        ///	SELECT * 
        ///	FROM sys.dm_xe_sessions
        ///	WHERE name = &apos;DBAChecks_1&apos;
        ///	)
        ///BEGIN
        ///	ALTER EVENT SESSION DBAChecks_1
        ///	ON SERVER
        ///	State = STOP
        ///END
        ///IF EXISTS(
        ///	SELECT * 
        ///	FROM sys.dm_xe_sessions
        ///	WHERE name = &apos;DBAChecks_2&apos;
        ///	)
        ///BEGIN
        ///	ALTER EVENT SESSION DBAChecks_2
        ///	ON SERVER
        ///	State = STOP
        ///END.
        /// </summary>
        internal static string SQLStopEventSessions {
            get {
                return ResourceManager.GetString("SQLStopEventSessions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS(
        ///	SELECT * 
        ///	FROM sys.dm_xe_database_sessions
        ///	WHERE name = &apos;DBAChecks_1&apos;
        ///	)
        ///BEGIN
        ///	ALTER EVENT SESSION DBAChecks_1
        ///	ON DATABASE
        ///	State = STOP
        ///END
        ///IF EXISTS(
        ///	SELECT * 
        ///	FROM sys.dm_xe_database_sessions
        ///	WHERE name = &apos;DBAChecks_2&apos;
        ///	)
        ///BEGIN
        ///	ALTER EVENT SESSION DBAChecks_2
        ///	ON DATABASE
        ///	State = STOP
        ///END.
        /// </summary>
        internal static string SQLStopEventSessionsAzure {
            get {
                return ResourceManager.GetString("SQLStopEventSessionsAzure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT configuration_id,CAST(value as BIGINT) as value,CAST(value_in_use as BIGINT) as value_in_use
        ///FROM sys.configurations.
        /// </summary>
        internal static string SQLSysConfig {
            get {
                return ResourceManager.GetString("SQLSysConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DBCC TRACESTATUS(-1).
        /// </summary>
        internal static string SQLTraceFlags {
            get {
                return ResourceManager.GetString("SQLTraceFlags", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT wait_type,
        ///       waiting_tasks_count,
        ///       wait_time_ms,
        ///       signal_wait_time_ms
        ///FROM sys.dm_os_wait_stats WITH (NOLOCK)
        ///WHERE [wait_type] NOT IN ( N&apos;BROKER_EVENTHANDLER&apos;, N&apos;BROKER_RECEIVE_WAITFOR&apos;, N&apos;BROKER_TASK_STOP&apos;, N&apos;BROKER_TO_FLUSH&apos;,
        ///                           N&apos;BROKER_TRANSMITTER&apos;, N&apos;CHECKPOINT_QUEUE&apos;, N&apos;CHKPT&apos;, N&apos;CLR_AUTO_EVENT&apos;,
        ///                           N&apos;CLR_MANUAL_EVENT&apos;, N&apos;CLR_SEMAPHORE&apos;, N&apos;CXCONSUMER&apos;, N&apos;DBMIRROR_DBM_EVENT&apos;,
        ///                           N&apos;DBMIRROR_EVENTS_QU [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SQLWaits {
            get {
                return ResourceManager.GetString("SQLWaits", resourceCulture);
            }
        }
    }
}
