$targetDir = $PSScriptRoot
$classNameTemplate = "Numeric{0}Extensions"
$fileNameTemplate = "{0}.cs"

$types = "sbyte", "short", "int", "long", "Single", "double"

$types | ForEach-Object {

	$type = $_
	$typeCapitalized = $type.Substring(0,1).ToUpper() + $type.Substring(1)
	$className = $classNameTemplate -f $typeCapitalized
	$fileName = $fileNameTemplate -f $className
	$filePath = [System.IO.Path]::Combine($targetDir, $fileName)

	function Out { param([string]$line) $line | Out-File -FilePath $filePath -Encoding UTF8 -Append }

	Write-Output "writing $filePath..."

	if (Test-Path $filePath) { Remove-Item $filePath }

	Out "using System;"
	Out ""
	Out "namespace wimm.Guardian"
	Out "{"
    Out "    /// <summary>"
    Out "    /// Adds range validation for the <see cref=`"$type`"/> type."
    Out "    /// </summary>"
    Out "    public static class $className"
    Out "    {"
    Out "        /// <summary>"
	Out "        /// Throws an <see cref=`"ArgumentOutOfRangeException`"/> if the value of"
	Out "        /// <paramref name=`"target`"/> is less than or equal to 0."
	Out "        /// </summary>"
	Out "        /// <returns><paramref name=`"target`"/>.</returns>"
	Out "        /// <exception cref=`"ArgumentNullException`">"
	Out "        /// <paramref name=`"target`"/> is <c>null</c>."
	Out "        /// </exception>"
	Out "        public static Argument<$type> IsPositive(this Argument<$type> target)"
	Out "        {"
	Out "            target.Require(nameof(target)).IsNotNull();"
	Out "            return target.IsGreaterThan<$type>(0);"
	Out "        }"
	Out ""
	Out "        /// <summary>"
	Out "        /// Throws an <see cref=`"ArgumentOutOfRangeException`"/> if the value of"
	Out "        /// <paramref name=`"target`"/> is greater than or equal to 0."
	Out "        /// </summary>"
	Out "        /// <returns><paramref name=`"target`"/>.</returns>"
	Out "        /// <exception cref=`"ArgumentNullException`">"
	Out "        /// <paramref name=`"target`"/> is <c>null</c>."
	Out "        /// </exception>"
	Out "        public static Argument<$type> IsNegative(this Argument<$type> target)"
	Out "        {"
	Out "            target.Require(nameof(target)).IsNotNull();"
	Out "            return target.IsLessThan<$type>(0);"
	Out "        }"
	Out ""
	Out "        /// <summary>"
	Out "        /// Throws an <see cref=`"ArgumentOutOfRangeException`"/> if the value of"
	Out "        /// <paramref name=`"target`"/> is greater than 0."
	Out "        /// </summary>"
	Out "        /// <returns><paramref name=`"target`"/>.</returns>"
	Out "        /// <exception cref=`"ArgumentNullException`">"
	Out "        /// <paramref name=`"target`"/> is <c>null</c>."
	Out "        /// </exception>"
	Out "        public static Argument<$type> IsNotPositive(this Argument<$type> target)"
	Out "        {"
	Out "            target.Require(nameof(target)).IsNotNull();"
	Out "            return target.IsNotGreaterThan<$type>(0);"
	Out "        }"
	Out ""
	Out "        /// <summary>"
	Out "        /// Throws an <see cref=`"ArgumentOutOfRangeException`"/> if the value of"
	Out "        /// <paramref name=`"target`"/> is less than 0."
	Out "        /// </summary>"
	Out "        /// <returns><paramref name=`"target`"/>.</returns>"
	Out "        /// <exception cref=`"ArgumentNullException`">"
	Out "        /// <paramref name=`"target`"/> is <c>null</c>."
	Out "        /// </exception>"
	Out "        public static Argument<$type> IsNotNegative(this Argument<$type> target)"
	Out "        {"
	Out "            target.Require(nameof(target)).IsNotNull();"
	Out "            return target.IsNotLessThan<$type>(0);"
	Out "        }"
	Out "    }"
	Out "}"
	Out ""

	Write-Output "done"
}