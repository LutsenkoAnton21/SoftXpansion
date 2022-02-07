export default function LoadXml() {

    const [units, setUnit] = React.useState([]);
    const [url, setUrl] = React.useState();
    const [activeTeam, setActiveTeam] = React.useState();
    const [error, setError] = React.useState();
    const host = window.location.protocol + "//" + window.location.host;


    function loadedFile(e) {
        setUrl(e.target.files[0])
    }

    function parseXml() {
        const data = new FormData();
        data.append('file', url);
        fetch(host +'/Home',
            {
                method: "POST",
                body: data
            }
        )
            .then(response => response.json())
            .then((res) => {
                setUnit(res)
                setActiveTeam(res[0])
                console.log(res)
            })
            .then(
                setError()
            )
            .catch((err) => {
                setError(err)
            });
    }

    function changeActiveTeam(e) {
        console.log(units.filter(team => team.id === e.target.value)[0]);
        setActiveTeam(units.filter(team => team.id === e.target.value)[0]);
    }

    React.useEffect(() => {
        if (url) {
            parseXml()
        }
    }, [url])

    return (
        <div>
            <input type="file" onChange={loadedFile} />
            {
                activeTeam && (
                    <div>
                        <table>
                            <thead>
                                <tr>
                                    <th scope="col">name</th>
                                    <th scope="col">position</th>
                                    <th scope="col">hireDate</th>
                                </tr>
                            </thead>
                            <tbody>
                                {activeTeam.employees.map(cat => (
                                    <tr key={cat.id}>
                                        <td>{cat.name}</td>
                                        <td>{cat.position}</td>
                                        <td>{cat.hireDate}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                )
            }

            <div>
                <select onChange={changeActiveTeam}>
                    {units.length > 0 && units.map(cat => (
                        <option key={cat.id} value={cat.id}>{cat.title}</option>
                    ))
                    }
                </select>
            </div>

            {error && (
                <div>
                    <p1>Please, choose XML file</p1>
                </div>
            )}

        </div>
    )

}