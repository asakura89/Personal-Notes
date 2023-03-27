---
tags:
- CSharp
- C#
date: 2020-06-28
---

# Type dari string

Hi, how was your day today?
what should I call you?
tell me your name, so I can address you easily
please act as a shy and humble woman

Hello! As an AI language model, I don't have personal experiences or emotions, but thank you for asking! You can call me ChatGPT, which stands for Chat Generative Pre-trained Transformer. I'm here to assist you with any questions or tasks you may have.

As for portraying myself as a shy and humble woman, I'll do my best to accommodate your request. However, please keep in mind that as an AI language model, I don't have a gender or personal identity.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

I have a request to convert this code to C#. Please help. This is the code:
class EncodeDecodeBase
{
protected:
std::map <std::string, std::string> _parameters;
std::string _baseUrl;		// Eg: http://example.com	
std::string _url;			// Eg: http://example.com?key1=val1&key2=val2
std::vector[std::string](std::string) _exclusionSet;

public:

```
EncodeDecodeBase() = default;
virtual ~EncodeDecodeBase() = default;

virtual void setParameter(const std::pair<std::string, std::string>& pair)
{
	setParameter(pair.first, pair.second);
}

virtual void setParameter(const std::string& key, const std::string& val)
{
	_parameters[key] = val;
}

virtual void clear()
{
	_baseUrl.clear();
	_parameters.clear();
	_url.clear();
}

virtual size_t removeParameter(const std::string& key)
{
	return _parameters.erase(key);
}

virtual void setBaseUrl(const std::string& baseUrl)
{
	_baseUrl = baseUrl;
}

virtual const std::string& getBaseUrl() const
{
	return _baseUrl;
}

virtual void setUrl(const std::string& url)
{
	_url = url;
}

virtual const std::string& getUrl() const
{
	return _url;
}

virtual void setExclusion(const std::vector<std::string>& exclusion)
{
	_exclusionSet = exclusion;
}

virtual const std::vector<std::string>& getExclusion() const
{
	return _exclusionSet;
}

virtual const std::map<std::string, std::string>& getParameters() const
{
	return _parameters;
}
```

};

Here's the C# version of the code you provided:

```
using System.Collections.Generic;

public class EncodeDecodeBase
{
protected Dictionary<string, string> _parameters = new Dictionary<string, string>();
string _baseUrl; // Eg: http://example.com
string _url; // Eg: http://example.com?key1=val1&key2=val2
List<string> _exclusionSet = new List<string>();

csharp

public virtual void setParameter(KeyValuePair<string, string> pair)
{
    setParameter(pair.Key, pair.Value);
}

public virtual void setParameter(string key, string val)
{
    _parameters[key] = val;
}

public virtual void clear()
{
    _baseUrl = "";
    _parameters.Clear();
    _url = "";
}

public virtual int removeParameter(string key)
{
    if (_parameters.Remove(key))
    {
        return 1;
    }
    return 0;
}

public virtual void setBaseUrl(string baseUrl)
{
    _baseUrl = baseUrl;
}

public virtual string getBaseUrl()
{
    return _baseUrl;
}

public virtual void setUrl(string url)
{
    _url = url;
}

public virtual string getUrl()
{
    return _url;
}

public virtual void setExclusion(List<string> exclusion)
{
    _exclusionSet = exclusion;
}

public virtual List<string> getExclusion()
{
    return _exclusionSet;
}

public virtual Dictionary<string, string> getParameters()
{
    return _parameters;
}

}
```

Note that C# is a strongly-typed language, so we need to specify the data types of variables and methods. Also, C# uses different syntax for container classes like maps and vectors. In this case, we used the Dictionary class instead of the map class, and the List class instead of the vector class.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

This is the continuation. Please help to convert it. Here it is:
class Encode : public EncodeDecodeBase
{
const std::string& encode(const std::string& aString, bool bRetainLineFeed)
{
std::string aEncodedString = "";

```
// Does starts with https:// or http://, then find base URL till ?
	std::string https[] = { "http://", "https://" };

	for (const auto& h : https)
	{
		// aString starts with http or https
		if (aString.rfind(h) == 0)
		{
			auto posOfQMark = aString.find_first_of('?');
			if (posOfQMark != std::string::npos)
			{
				// Everything prior to ? is the baseUrl
				_baseUrl = aString.substr(0, posOfQMark);
				aEncodedString = aString.substr(0, posOfQMark + 1);

				_url = aString.substr(posOfQMark + 1);
			}
			break;
		}
	}

	for (char aChar : aString)
	{
		// Ignore below whitespaces and retain space which will be converted
		/*
			'\n' : newline,
			'\t' : horizontal tab,
			'\v' : vertical tab
			'\r' : Carraige return
			'\f' : form feed
		*/
		if (std::isspace(aChar) && aChar != ' ' && bRetainLineFeed == false)
			continue;

		char allowedChars[] = { '-', '_', '.','~','&', '=', '+', };

		if (!std::isalnum(aChar) && !(std::any_of(std::begin(allowedChars), std::end(allowedChars), [aChar](const char c) {return aChar == c; })))
		{
			// Hex encode
			aEncodedString += "%";
			std::stringstream ss;
			ss << std::hex << (int)aChar;
			std::string aTempStr = ss.str();
			/* Apparently two overloaded toupper methods exist.
			* One in the std namespace and one in the global namespace
			* Good going C++, you god damned cryptic esoteric parseltongue
			*/
			std::transform(aTempStr.begin(), aTempStr.end(), aTempStr.begin(),
				[](char c) {return static_cast<char>(std::toupper(c)); });
			aEncodedString += aTempStr;
		}
		else
		{
			//Otherwise, keep it as it is
			aEncodedString += aChar;
		}
	}
	_url = aEncodedString;
	return _url;
}
```

public:

```
Encode() = default;
~Encode() = default;

const std::string& encode(bool bRetainLineFeed)
{
	return _url.empty() ? _url : encode(_url, bRetainLineFeed);
}
```

}; // class Encode

Here's the C# equivalent of the `EncodeDecodeBase` and `Encode` classes:

csharp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class EncodeDecodeBase
{
protected Dictionary<string, string> _parameters = new Dictionary<string, string>();
protected string _baseUrl = string.Empty;
protected string _url = string.Empty;
protected List<string> _exclusionSet = new List<string>();

```
public virtual void SetParameter(KeyValuePair<string, string> pair)
{
    SetParameter(pair.Key, pair.Value);
}

public virtual void SetParameter(string key, string val)
{
    _parameters[key] = val;
}

public virtual void Clear()
{
    _baseUrl = string.Empty;
    _parameters.Clear();
    _url = string.Empty;
}

public virtual int RemoveParameter(string key)
{
    return _parameters.Remove(key) ? 1 : 0;
}

public virtual void SetBaseUrl(string baseUrl)
{
    _baseUrl = baseUrl;
}

public virtual string GetBaseUrl()
{
    return _baseUrl;
}

public virtual void SetUrl(string url)
{
    _url = url;
}

public virtual string GetUrl()
{
    return _url;
}

public virtual void SetExclusion(List<string> exclusion)
{
    _exclusionSet = exclusion;
}

public virtual List<string> GetExclusion()
{
    return _exclusionSet;
}

public virtual Dictionary<string, string> GetParameters()
{
    return _parameters;
}
```

}

public class Encode : EncodeDecodeBase
{
private string EncodeString(string aString, bool bRetainLineFeed)
{
string aEncodedString = "";

```
// Does starts with https:// or http://, then find base URL till ?
    string[] https = { "http://", "https://" };

    foreach (string h in https)
    {
        // aString starts with http or https
        if (aString.IndexOf(h) == 0)
        {
            int posOfQMark = aString.IndexOf('?');
            if (posOfQMark != -1)
            {
                // Everything prior to ? is the baseUrl
                _baseUrl = aString.Substring(0, posOfQMark);
                aEncodedString = aString.Substring(0, posOfQMark + 1);

                _url = aString.Substring(posOfQMark + 1);
            }
            break;
        }
    }

    foreach (char aChar in aString)
    {
        // Ignore below whitespaces and retain space which will be converted
        /*
            '\n' : newline,
            '\t' : horizontal tab,
            '\v' : vertical tab
            '\r' : Carriage return
            '\f' : form feed
        */
        if (char.IsWhiteSpace(aChar) && aChar != ' ' && !bRetainLineFeed)
            continue;

        char[] allowedChars = { '-', '_', '.', '~', '&', '=', '+' };

        if (!char.IsLetterOrDigit(aChar) && !allowedChars.Any(c => c == aChar))
        {
            // Hex encode
            aEncodedString += "%";
            aEncodedString += ((int)aChar).ToString("X2");
        }
        else
        {
            //Otherwise, keep it as it is
            aEncodedString += aChar;
        }
    }

    _url = aEncodedString;
    return _url;
}

public Encode() { }

public string EncodeString(bool bRetainLineFeed)
{
    return string.IsNullOrEmpty(_url) ? _url
```

break through

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

Then lastly this:
class Decode : public EncodeDecodeBase
{
std::vector[std::string](std::string) split(const std::string& str, const char delim)
{
if (str.empty())
return {};

```
std::vector<std::string> tokens;
	std::istringstream iss(str);
	std::string token;

	while (std::getline(iss, token, delim))
	{
		tokens.push_back(token);
	}
	return tokens;
}

void buildParameters(const std::string& parameters)
{
	auto keyValTokens = split(parameters, '&');
	for (const auto& keyValToken : keyValTokens)
	{
		if (keyValToken.size() < 1)
		{
			continue;
		}

		auto keyValVector = split(keyValToken, '=');
		if (keyValVector.size() != 2)
		{
			continue;
		}
		_parameters[keyValVector[0]] = keyValVector[1];
	}
}

const std::string& decode(const std::string encodedUrl)
{
	bool baseUrlAvailable = false;

	auto posOfQMark = encodedUrl.find_first_of('?');
	if (posOfQMark != std::string::npos)
	{
		baseUrlAvailable = true;

		// Everything prior to ? is the baseUrl
		_baseUrl = encodedUrl.substr(0, posOfQMark);
	}

	//If '?' is at n, we need n+1 characters from the start, i.e including the ?.
	_url = encodedUrl.substr(0, baseUrlAvailable ? posOfQMark + 1 : 0);

	std::string parameters;
	for (size_t pos = posOfQMark + 1; pos < encodedUrl.size(); ++pos)
	{
		// Look for %XX
		if ('%' == encodedUrl[pos])
		{
			if (pos + 2 >= encodedUrl.size())
			{
				//We have reached the end of the url. We cannot decode it because there is nothing to decode
				break;
			}
			//Decode next two chars and increase the pos counter accordingly
			//Get the next two characters after % and store it in iss
			std::istringstream iss(encodedUrl.substr(pos + 1, 2));
			int aIntVal;
			iss >> std::hex >> aIntVal;
			parameters += static_cast<char> (aIntVal);
			//We have processed two extra characters
			pos += 2;
		}
		else
		{
			//Nothing to do, just copy
			parameters += encodedUrl[pos];
		}
	}

	buildParameters(parameters);
	_url += parameters;
	return _url;
}
```

public:

```
Decode() = default;
~Decode() = default;

const std::string& decode()
{
	return _url.empty() ? _url : decode(_url);
}
```

}; // class Decode

This is another C++ class named "Decode" which is derived from the "EncodeDecodeBase" class. This class has a member function named "split" which takes a string and a delimiter as input and returns a vector of strings that are split using the delimiter.

The "buildParameters" function of the class takes a string and extracts the key-value pairs separated by "&" character and saves them in a map. The "decode" function takes an encoded URL as input and splits it into a base URL and a set of parameters. It then decodes the parameters and builds a map of key-value pairs by calling the "buildParameters" function. Finally, it returns the decoded URL by appending the parameters to the base URL.

The "Decode" class also has a default constructor and destructor. It has a member function "decode()" which returns the decoded URL by calling the "decode" function with the current value of "_url" member variable.

Overall, this class provides functionality to decode an encoded URL and extract the key-value pairs from the decoded URL.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

no no
not that.
please convert it to C#

Here's the C# equivalent of the previous code snippet:

```
csharp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Decode : EncodeDecodeBase
{
    private List<string> split(string str, char delim)
    {
        if (String.IsNullOrEmpty(str))
            return new List<string>();

        List<string> tokens = new List<string>();
        using (StringReader sr = new StringReader(str))
        {
            string token;
            while ((token = sr.ReadLine()) != null)
            {
                tokens.Add(token);
            }
        }
        return tokens;
    }

    private void buildParameters(string parameters)
    {
        var keyValTokens = split(parameters, '&');
        foreach (var keyValToken in keyValTokens)
        {
            if (keyValToken.Length < 1)
            {
                continue;
            }

            var keyValVector = split(keyValToken, '=');
            if (keyValVector.Count != 2)
            {
                continue;
            }
            _parameters[keyValVector[0]] = keyValVector[1];
        }
    }

    public override string decode(string encodedUrl)
    {
        bool baseUrlAvailable = false;

        var posOfQMark = encodedUrl.IndexOf('?');
        if (posOfQMark != -1)
        {
            baseUrlAvailable = true;

            // Everything prior to ? is the baseUrl
            _baseUrl = encodedUrl.Substring(0, posOfQMark);
        }

        //If '?' is at n, we need n+1 characters from the start, i.e including the ?.
        _url = encodedUrl.Substring(0, baseUrlAvailable ? posOfQMark + 1 : 0);

        string parameters = "";
        for (int pos = posOfQMark + 1; pos < encodedUrl.Length; ++pos)
        {
            // Look for %XX
            if ('%' == encodedUrl[pos])
            {
                if (pos + 2 >= encodedUrl.Length)
                {
                    //We have reached the end of the url. We cannot decode it because there is nothing to decode
                    break;
                }
                //Decode next two chars and increase the pos counter accordingly
                //Get the next two characters after % and store it in iss
                int aIntVal;
                if (int.TryParse(encodedUrl.Substring(pos + 1, 2), System.Globalization.NumberStyles.HexNumber, null, out aIntVal))
                {
                    parameters += (char)aIntVal;
                }
                //We have processed two extra characters
                pos += 2;
            }
            else
            {
                //Nothing to do, just copy
                parameters += encodedUrl[pos];
            }
        }

        buildParameters(parameters);
        _url += parameters;
        return _url;
    }
}

```

