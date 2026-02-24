import { useEffect, useRef, useState } from "react";

interface AutocompleteProps<T> {
  value: T | null;
  onChange: (value: T | null) => void;
  options: T[];
  isLoading?: boolean;
  onSearch: (search: string) => void;
  getOptionLabel: (option: T) => string;
  getOptionValue: (option: T) => string | number;
  placeholder?: string;
  inputClass?: string;
}

export function Autocomplete<T>({
  onChange,
  options,
  isLoading = false,
  onSearch,
  getOptionLabel,
  getOptionValue,
  placeholder = "Buscar...",
  inputClass,
}: AutocompleteProps<T>) {
  const [inputValue, setInputValue] = useState("");
  const [isOpen, setIsOpen] = useState(false);
  const containerRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    function handleClickOutside(event: MouseEvent) {
      if (
        containerRef.current &&
        !containerRef.current.contains(event.target as Node)
      ) {
        setIsOpen(false);
      }
    }

    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  function handleInputChange(newValue: string) {
    setInputValue(newValue);
    onSearch(newValue);
    setIsOpen(true);

    if (newValue === "") {
      onChange(null); // permite limpar corretamente
    }
  }

  function handleSelect(option: T) {
    onChange(option);
    setInputValue(getOptionLabel(option));
    setIsOpen(false);
  }

  return (
    <div ref={containerRef} className={`relative`}>
      <input
        type="text"
        value={inputValue}
        onChange={(e) => handleInputChange(e.target.value)}
        onFocus={() => setIsOpen(true)}
        placeholder={placeholder}
        className={inputClass}
      />

      {isOpen && (
        <div className="absolute z-50 mt-1 w-full bg-white border rounded-md shadow max-h-60 overflow-y-auto px-1">
          {isLoading && (
            <div className="p-2 text-sm text-gray-500">Carregando...</div>
          )}

          {!isLoading && options.length === 0 && (
            <div className="p-2 text-sm text-gray-500">
              Nenhum resultado encontrado
            </div>
          )}

          {!isLoading &&
            options.map((option) => (
              <div
                key={getOptionValue(option)}
                onClick={() => handleSelect(option)}
                className="px-3 py-2 cursor-pointer hover:bg-gray-100"
              >
                {getOptionLabel(option)}
              </div>
            ))}
        </div>
      )}
    </div>
  );
}
